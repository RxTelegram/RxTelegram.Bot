using System;
using System.Collections.Generic;
using System.Linq;

namespace RxTelegram.Bot.Reactive
{
    internal class Observable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        public event EventHandler AddObserver;

        public event EventHandler RemoveObserver;

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                AddObserver?.Invoke(this, EventArgs.Empty);
            }

            return new Unsubscriber(() => Remove(observer));
        }

        public bool HasObserver => _observers.Any();

        private void Remove(IObserver<T> observer)
        {
            _observers.RemoveAll(x => x == observer);
            RemoveObserver?.Invoke(this, EventArgs.Empty);
        }

        internal void OnNext(T updateMessage)
        {
            if (!HasObserver)
            {
                return;
            }

            foreach (var observer in _observers)
            {
                observer.OnNext(updateMessage);
            }
        }

        internal void OnException(Exception exception)
        {
            if (!HasObserver)
            {
                return;
            }

            foreach (var observer in _observers)
            {
                observer.OnError(exception);
            }
        }
    }
}
