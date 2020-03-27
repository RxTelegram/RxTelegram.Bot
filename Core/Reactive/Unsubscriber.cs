using System;

namespace Core.Reactive
{
    internal class Unsubscriber : IDisposable
    {
        private readonly Action _dispose;

        public Unsubscriber(Action action) => _dispose = action;

        public void Dispose() => _dispose?.Invoke();
    }
}
