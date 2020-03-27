using System;

namespace RxTelegram.Bot.Reactive
{
    internal class Unsubscriber : IDisposable
    {
        private readonly Action _dispose;

        public Unsubscriber(Action action) => _dispose = action;

        public void Dispose() => _dispose?.Invoke();
    }
}
