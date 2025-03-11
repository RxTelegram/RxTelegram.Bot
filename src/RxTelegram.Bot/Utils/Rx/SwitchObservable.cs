using System;

namespace RxTelegram.Bot.Utils.Rx;

internal class SwitchObservable<T> : IObservable<T>
{
  private readonly IObservable<IObservable<T>> _source;

  public SwitchObservable(IObservable<IObservable<T>> source)
  {
    _source = source ?? throw new ArgumentNullException(nameof(source));
  }
  public IDisposable Subscribe(IObserver<T> observer)
  {
    var switchObserver = new SwitchObserver(observer);
    var stream = _source.Subscribe(switchObserver);
    return new DisposableAction(() =>
    {
      stream.Dispose();
      switchObserver.Dispose();
    });
  }

  private class SwitchObserver : IObserver<IObservable<T>>, IDisposable
  {
    private readonly object _lock = new();
    private IObserver<T> _observer;
    private IDisposable _subscription;
    private bool _isDisposed = false;
    public SwitchObserver(IObserver<T> observer)
    {
      this._observer = observer ?? throw new ArgumentNullException(nameof(observer));
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public void OnCompleted()
    {
      lock (_lock)
      {
        if (_isDisposed) return;
        _observer?.OnCompleted();
        Dispose();
      }
    }

    public void OnError(Exception error)
    {
      lock (_lock)
      {
        if (_isDisposed) return;
        _observer?.OnError(error);
        Dispose();
      }
    }

    public void OnNext(IObservable<T> stream)
    {
      if (stream == null) throw new ArgumentNullException(nameof(stream));

      lock (_lock)
      {
        if (_isDisposed)
          throw new ObjectDisposedException(nameof(SwitchObserver));

        _subscription?.Dispose();
        _subscription = stream.Subscribe(_observer);
      }
    }
    void Dispose(bool explicitDisposing)
    {
      if (_isDisposed) return;

      if (explicitDisposing)
      {
        _subscription?.Dispose();
        _subscription = null;
        _observer = null;
      }

      _isDisposed = true;
    }

    ~SwitchObserver() => Dispose(false);
  }
}