using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace RxTelegram.Bot.Reactive
{
    internal sealed class Observable<T> : IObservable<T>
    {
        private readonly ObservableCollection<IObserver<T>> _observers = new ObservableCollection<IObserver<T>>();

        internal event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => _observers.CollectionChanged += value;
            remove => _observers.CollectionChanged -= value;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return new Unsubscriber(() => Remove(observer));
        }

        public bool HasObserver => _observers.Any();

        private void Remove(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                return;
            }
            _observers.Remove(observer);
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
