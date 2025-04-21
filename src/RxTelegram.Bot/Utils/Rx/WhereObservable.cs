using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class WhereObservable<T>(IObservable<T> source, Func<T, bool> predicate) : IObservable<T>
{
    private readonly IObservable<T> _source = source ?? throw new ArgumentNullException(nameof(source));
    private readonly Func<T, bool> _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));

    public IDisposable Subscribe(IObserver<T> observer)
    {
        var where = new WhereObserver(observer, _predicate);
        var subscription = _source.Subscribe(where);
        return new DisposableAction(() =>
        {
            subscription.Dispose();
            where.Dispose();
        });
    }
    private sealed class WhereObserver(IObserver<T> observer, Func<T, bool> predicate) : IObserver<T>, IDisposable
    {
        private readonly object _lock = new();
        private readonly Func<T, bool> _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        private IObserver<T> _observer = observer ?? throw new ArgumentNullException(nameof(observer));
        private bool _isCompleted;
        private bool _isDisposed;

        public void OnCompleted()
        {
            lock (_lock)
            {
                if (_isCompleted || _isDisposed)
                {
                    return;
                }

                _isCompleted = true;
            _observer?.OnCompleted();
            }
        }

        public void OnError(Exception error)
        {
            lock (_lock)
            {
                if (_isCompleted || _isDisposed)
                {
                    return;
                }

                _isCompleted = true;
                _observer?.OnError(error);
            }
        }

        public void OnNext(T value)
        {
            lock (_lock)
            {
                if (_isCompleted || _isDisposed)
                {
                    return;
                }

                var isPassed = false;
                try
                {
                    isPassed = _predicate(value);
                }
                catch (Exception error)
                {
                    OnError(error);
                }
                if (isPassed)
                {
                    _observer.OnNext(value);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool explicitDisposing)
        {
            if (_isDisposed) return;

            lock (_lock)
            {
                if (explicitDisposing)
                {
                    _observer = null;
                }
                _isDisposed = true;
            }
        }
        ~WhereObserver() => Dispose(false);
    }
}
