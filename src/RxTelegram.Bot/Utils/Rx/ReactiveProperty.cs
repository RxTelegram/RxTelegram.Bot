using RxTelegram.Bot.Utils.Rx.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RxTelegram.Bot.Utils.Rx;

public class ReactiveProperty<T>() : ISubject<T>, IDisposable
{
    private static readonly List<IObserver<T>> Terminated = [];
    private readonly object _lock = new object();
    private Exception _error;
    private T _current;
    public T Current
    {
        get => _current;
        protected set { _current = value; HasValue = true; }
    }
    public bool HasValue { get; private set; }
    private List<IObserver<T>> _observers = new();
    public bool IsDisposed { get; private set; }
    public bool IsError => _error != null;
    public Exception Error => _error;

    public ReactiveProperty(T initValue) : this()
    {
        Current = initValue;
    }

    public void OnCompleted()
    {
        lock (_lock)
        {
            ThrowIfDisposed();
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }

            _observers = Terminated;
        }
    }
    public void OnError(Exception error)
    {
        lock (_lock)
        {
            ThrowIfDisposed();
            _error = error;
            Current = default;
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnError(error);
                }
                catch (Exception ex)
                {
                    //ignore
                    // if observer doesn't have exception handler block
                    // it will lead to breaking process and throwing exception to outer scope
                    ExceptionHelpers.ThrowIfFatal(ex);
                }
            }

            _observers = Terminated;
        }
    }
    public void OnNext(T value)
    {
        lock (_lock)
        {
            ThrowIfDisposed();
            Current = value;

            foreach (var observer in _observers)
            {
                observer.OnNext(value);
            }
        }
    }
    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock (_lock)
        {
            ThrowIfDisposed();
            if (_observers == Terminated)
            {
                observer.OnCompleted();
                return DisposableAction.Empty;
            }

            _observers.Add(observer);
            if (HasValue)
            {
                observer.OnNext(Current);
            }

            return new DisposableAction(() =>
                {
                    lock (_lock)
                    {
                        _observers.Remove(observer);
                    }
                });
        }
    }

    protected void ThrowIfDisposed()
    {
        if (IsDisposed)
        {
            throw new ObjectDisposedException(nameof(ReactiveProperty<T>));
        }
    }

    ~ReactiveProperty() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool explicitDisposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (explicitDisposing)
        {
            OnCompleted();
            Interlocked.Exchange(ref _observers, Terminated);
        }

        IsDisposed = true;
    }
}
