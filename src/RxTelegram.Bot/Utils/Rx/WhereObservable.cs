using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class WhereObservable<T> : IObservable<T>
{
  private readonly IObservable<T> _source;
  internal readonly Func<T, bool> _predicate;

  public WhereObservable(IObservable<T> source, Func<T, bool> predicate)
  {
    _source = source ?? throw new ArgumentNullException(nameof(source));
    _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
  }
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
  private class WhereObserver : IObserver<T>, IDisposable
  {
    private readonly object _lock = new();
    private readonly Func<T, bool> _predicate;
    private IObserver<T> _observer;
    private bool _isCompleted;
    private bool _isDisposed;

    public WhereObserver(IObserver<T> observer, Func<T, bool> predicate)
    {
      _observer = observer ?? throw new ArgumentNullException(nameof(observer));
      _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    }

    public void OnCompleted()
    {
      if (_isCompleted || _isDisposed) return;
      _isCompleted = true;
      _observer?.OnCompleted();
    }

    public void OnError(Exception error)
    {
      lock (_lock)
      {
        if (_isCompleted || _isDisposed) return;
        _isCompleted = true;
        _observer?.OnError(error);
      }
    }

    public void OnNext(T value)
    {
      lock (_lock)
      {
        if (_isCompleted || _isDisposed) return;

        bool isPassed = false;
        try
        {
          isPassed = _predicate(value);
        }
        catch (Exception error)
        {
          OnError(error);
        }
        if (isPassed)
          _observer.OnNext(value);
      }
    }

    public void Dispose()
    {
      lock (_lock)
      {
        _isDisposed = true;
        _observer = null;
      }
    }
  }
}