using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class DoOnSubscribeObservable<T> : IObservable<T>
{
  private readonly IObservable<T> _source;
  private readonly Action _onSbuscribe;

  public DoOnSubscribeObservable(IObservable<T> source, Action onSubscribe)
  {
    this._source = source ?? throw new ArgumentNullException(nameof(source));
    this._onSbuscribe = onSubscribe ?? throw new ArgumentNullException(nameof(onSubscribe));
  }

  public IDisposable Subscribe(IObserver<T> observer)
  {

    var subscription = _source.Subscribe(observer);
    _onSbuscribe();
    return subscription;
  }
}