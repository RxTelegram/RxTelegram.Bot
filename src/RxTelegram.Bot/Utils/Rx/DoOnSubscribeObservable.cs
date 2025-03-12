using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class DoOnSubscribeObservable<T>(IObservable<T> source, Action onSubscribe) : IObservable<T>
{
    private readonly IObservable<T> _source = source ?? throw new ArgumentNullException(nameof(source));
    private readonly Action _onSubscribe = onSubscribe ?? throw new ArgumentNullException(nameof(onSubscribe));

    public IDisposable Subscribe(IObserver<T> observer)
    {

        var subscription = _source.Subscribe(observer);
        _onSubscribe();
        return subscription;
    }
}
