using System;
using System.Threading;

namespace RxTelegram.Bot.Utils.Rx;

internal class FinallyObservable<T> : IObservable<T>
{
  private readonly IObservable<T> _source;
  private readonly Action _onTerminate;

  public FinallyObservable(IObservable<T> source, Action onTerminate)
  {
    _source = source ?? throw new ArgumentNullException(nameof(source));
    _onTerminate = onTerminate ?? throw new ArgumentNullException(nameof(onTerminate));
  }

  public IDisposable Subscribe(IObserver<T> observer)
  {
    if (observer == null)
      throw new ArgumentNullException(nameof(observer));

    var finallyObserver = new FinallyObserver(observer, _onTerminate);
    var subscription = _source.Subscribe(finallyObserver);

    return new DisposableAction(() => finallyObserver.Dispose(subscription));
  }

  private class FinallyObserver : IObserver<T>
  {
    private readonly IObserver<T> _observer;
    private readonly Action _onTerminate;
    private int _terminated;

    public FinallyObserver(IObserver<T> observer, Action onTerminate)
    {
      _observer = observer;
      _onTerminate = onTerminate;
    }
    public void Dispose(IDisposable subscription)
    {
      subscription.Dispose();
      Terminate();
    }

    public void OnCompleted()
    {
      _observer.OnCompleted();
      Terminate();
    }

    public void OnError(Exception error)
    {
      try
      {
        _observer.OnError(error);
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

    public void OnNext(T value) => _observer.OnNext(value);

    private void Terminate()
    {
      if (Interlocked.Exchange(ref _terminated, 1) == 0)
      {
        _onTerminate();
      }
    }
  }
}