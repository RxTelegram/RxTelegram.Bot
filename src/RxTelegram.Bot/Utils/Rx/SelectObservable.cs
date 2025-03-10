using System;

namespace RxTelegram.Bot.Utils.Rx;
internal class SelectObservable<T, K> : IObservable<K>
{
  private readonly IObservable<T> _source;
  internal readonly Func<T, K> _selector;

  public SelectObservable(IObservable<T> source, Func<T, K> selector)
  {
    this._source = source ?? throw new ArgumentNullException(nameof(source)); 
    this._selector = selector ?? throw new ArgumentNullException(nameof(selector));
  }

  public IDisposable Subscribe(IObserver<K> observer)
  {
    if (observer == null)
      throw new ArgumentNullException(nameof(observer));
    var selectObserver = new SelectObserver(observer, _selector);
    return _source.Subscribe(selectObserver);
  }
  private class SelectObserver : IObserver<T>
  {
    private readonly IObserver<K> _observer;
    private readonly Func<T, K> _selector;

    public SelectObserver(IObserver<K> observer, Func<T, K> selector)
    {
      this._observer = observer;
      this._selector = selector;
    }

    public void OnCompleted() => _observer.OnCompleted();
    public void OnError(Exception error) => _observer.OnError(error);
    public void OnNext(T value)
    {
      K result;
      try
      {
        result = _selector(value);
      }
      catch (Exception ex)
      {
        _observer.OnError(ex);
        return;
      }

      _observer.OnNext(result);
    }
  }
}