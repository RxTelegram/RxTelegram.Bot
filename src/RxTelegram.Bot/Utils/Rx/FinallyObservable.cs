using System;
using System.Threading;

namespace RxTelegram.Bot.Utils.Rx;

internal class FinallyObservable<T>(IObservable<T> source, Action onTerminate) : IObservable<T>
{
    private readonly IObservable<T> _source = source ?? throw new ArgumentNullException(nameof(source));
    private readonly Action _onTerminate = onTerminate ?? throw new ArgumentNullException(nameof(onTerminate));

    public IDisposable Subscribe(IObserver<T> observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException(nameof(observer));
        }

        var finallyObserver = new FinallyObserver(observer, _onTerminate);
        var subscription = _source.Subscribe(finallyObserver);

        return new DisposableAction(() => finallyObserver.DisposeSubscription(subscription));
    }

    private sealed class FinallyObserver(IObserver<T> observer, Action onTerminate) : IObserver<T>
    {
        private int _terminated;

        public void DisposeSubscription(IDisposable subscription)
        {
            subscription.Dispose();
            Terminate();
        }

        public void OnCompleted()
        {
            observer.OnCompleted();
            Terminate();
        }

        public void OnError(Exception error)
        {
            try
            {
                observer.OnError(error);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.ThrowIfFatal(ex);
            }
            finally
            {
                Terminate();
            }
        }

        public void OnNext(T value) => observer.OnNext(value);

        private void Terminate()
        {
            if (Interlocked.Exchange(ref _terminated, 1) == 0)
            {
                onTerminate();
            }
        }
    }
}
