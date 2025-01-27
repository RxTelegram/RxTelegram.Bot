using System;
using System.Collections.Generic;

namespace RxTelegram.Bot.Utils.Rx;

/// <summary>
/// Simple subject that multicasts observable values
/// It can use on subscribe and on dispose action
/// </summary>
/// <typeparam name="TInput">Incoming type that the subject listens to</typeparam>
/// <typeparam name="TOut">Result type that the subject emits</typeparam>
public class CustomSubject<TInput, TOut> : IObserver<TInput>, IObservable<TOut>
{
  private readonly Func<TInput, TOut> _selector;
  private readonly Action _onSubscribe;
  private readonly Action _onDispose;
  private readonly List<IObserver<TOut>> _observers = new List<IObserver<TOut>>();
  public CustomSubject(Func<TInput, TOut> selector, Action onSubscribe = null, Action onDispose = null)
  {
    if (selector == null)
      throw new ArgumentNullException(nameof(selector));

    this._selector = selector;
    this._onSubscribe = onSubscribe;
    this._onDispose = onDispose;
  }

  public void OnCompleted()
  {
    for (int oid = 0; oid != _observers.Count; ++oid)
      _observers[oid].OnCompleted();
  }
  public void OnError(Exception error)
  {
    for (int oid = 0; oid != _observers.Count; ++oid)
      _observers[oid].OnError(error);
  }
  public void OnNext(TInput value)
  {
    var result = _selector(value);
    if (result == null) return;
    for (int oid = 0; oid != _observers.Count; ++oid)
      _observers[oid].OnNext(result);
  }
  public IDisposable Subscribe(IObserver<TOut> observer)
  {
    _observers.Add(observer);
    _onSubscribe?.Invoke();
    return new DisposableAction(() =>
    {
      _onDispose?.Invoke();
      _observers.Remove(observer);
    });
  }
}
