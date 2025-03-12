using System;

namespace RxTelegram.Bot.Utils.Rx;
internal class SelectObservable<TIn, TOut>(IObservable<TIn> source, Func<TIn, TOut> selector) : IObservable<TOut>
{
    private readonly IObservable<TIn> _source = source ?? throw new ArgumentNullException(nameof(source));
    private readonly Func<TIn, TOut> _selector = selector ?? throw new ArgumentNullException(nameof(selector));

    public IDisposable Subscribe(IObserver<TOut> observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException(nameof(observer));
        }

        var selectObserver = new SelectObserver(observer, _selector);
        return _source.Subscribe(selectObserver);
    }
    private class SelectObserver(IObserver<TOut> observer, Func<TIn, TOut> selector) : IObserver<TIn>
    {
        public void OnCompleted() => observer.OnCompleted();
        public void OnError(Exception error) => observer.OnError(error);
        public void OnNext(TIn value)
        {
            TOut result;
            try
            {
                result = selector(value);
            }
            catch (Exception ex)
            {
                observer.OnError(ex);
                return;
            }

            observer.OnNext(result);
        }
    }
}
