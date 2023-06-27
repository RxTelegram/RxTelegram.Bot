#if NETSTANDARD2_1
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RxTelegram.Bot.Utils
{
    internal static class ObservableExtensions
    {
        public static IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IObservable<T> observable) where T : class
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }

            return new ObservableAsyncEnumerable<T>(observable);
        }

        private sealed class ObservableAsyncEnumerable<T> : IObserver<T>, IAsyncEnumerable<T>, IAsyncEnumerator<T> where T : class
        {
            private readonly int _threadId;
            private AsyncIteratorState _state = AsyncIteratorState.New;
            private CancellationToken _cancellationToken;

            private readonly IObservable<T> _observable;
            private IDisposable _subscription;
            private ConcurrentQueue<T> _values = new ConcurrentQueue<T>();
            private Exception _exception;
            private bool _completed;

            private T _current;
            public T Current => _current;

            private SemaphoreSlim _enumerationSemaphore;

            public ObservableAsyncEnumerable(IObservable<T> observable)
            {
                _threadId = Environment.CurrentManagedThreadId;
                _observable = observable;
            }

            #region IObserver

            public void OnCompleted()
            {
                Volatile.Write(ref _completed, true);
                DisposeSubscription();
                _enumerationSemaphore.Release();
            }

            public void OnError(Exception error)
            {
                Volatile.Write(ref _completed, true);
                _exception = error;
                DisposeSubscription();
                _enumerationSemaphore.Release();
            }

            public void OnNext(T value)
            {
                _values.Enqueue(value);
                _enumerationSemaphore.Release();
            }

            #endregion

            #region IAsyncEnumerable

            public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var enumerator = _state == AsyncIteratorState.New && _threadId == Environment.CurrentManagedThreadId ? this : Clone();

                enumerator._state = AsyncIteratorState.Allocated;
                enumerator._cancellationToken = cancellationToken;
                enumerator._enumerationSemaphore = new SemaphoreSlim(0);

                return enumerator;
            }

            private ObservableAsyncEnumerable<T> Clone() => new ObservableAsyncEnumerable<T>(_observable);

            #endregion

            #region IAsyncEnumerator


            public ValueTask DisposeAsync()
            {
                _current = default;
                _state = AsyncIteratorState.Disposed;

                InternalDispose();

                return default;
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_state == AsyncIteratorState.Disposed)
                {
                    return false;
                }

                try
                {
                    _cancellationToken.ThrowIfCancellationRequested();

                    if (_state == AsyncIteratorState.Allocated)
                    {
                        _subscription = _observable.Subscribe(this);
                        _state = AsyncIteratorState.Iterating;
                    }

                    if (_state == AsyncIteratorState.Iterating)
                    {
                        while (true)
                        {
                            await _enumerationSemaphore.WaitAsync(_cancellationToken).ConfigureAwait(false);

                            var completed = Volatile.Read(ref _completed);

                            if (_values.TryDequeue(out _current))
                            {
                                return true;
                            }

                            if (!completed)
                            {
                                continue;
                            }

                            if (_exception != null)
                            {
                                throw _exception;
                            }

                            return false;
                        }
                    }

                    await DisposeAsync().ConfigureAwait(false);
                    return false;
                }
                catch
                {
                    await DisposeAsync().ConfigureAwait(false);
                    throw;
                }
            }

            private void DisposeSubscription() => Interlocked.Exchange(ref _subscription, null)?.Dispose();

            private void InternalDispose()
            {
                DisposeSubscription();

                _values = null;
                _exception = null;
            }

            #endregion


        }

        private enum AsyncIteratorState
        {
            New = 0,
            Allocated = 1,
            Iterating = 2,
            Disposed = -1,
        }
    }

}
#endif
