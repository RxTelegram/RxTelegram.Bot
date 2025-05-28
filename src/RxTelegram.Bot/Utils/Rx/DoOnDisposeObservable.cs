using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class DoOnDisposeObservable<T>(IObservable<T> source, Action onDispose) : IObservable<T>
{
    private readonly IObservable<T> _source = source ?? throw new ArgumentNullException(nameof(source));
    private readonly Action _onDispose = onDispose ?? throw new ArgumentNullException(nameof(onDispose));

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
