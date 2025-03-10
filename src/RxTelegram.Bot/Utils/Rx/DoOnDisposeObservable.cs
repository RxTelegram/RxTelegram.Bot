using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class DoOnDisposeObservable<T> : IObservable<T>
{
  private readonly IObservable<T> _source;
  private readonly Action _onDispose;

  public DoOnDisposeObservable(IObservable<T> source, Action onTerminate)
  {
    this._source = source ?? throw new ArgumentNullException(nameof(source));
    this._onDispose = onTerminate ?? throw new ArgumentNullException(nameof(onTerminate));
  }

  public IDisposable Subscribe(IObserver<T> observer)
  {

    var subscription = _source.Subscribe(observer);
    return new DisposableAction(() =>
      {
        subscription.Dispose();
        _onDispose();
      });
  }
}