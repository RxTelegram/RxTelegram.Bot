using System;
using System.Collections.Generic;

namespace RxTelegram.Bot.Reactive
{
    internal class Observable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return new Unsubscriber(() => Remove(observer));
        }

        private void Remove(IObserver<T> observer) => _observers.RemoveAll(x => x == observer);
    }
}
