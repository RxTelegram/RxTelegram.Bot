using System;

namespace RxTelegram.Bot.Utils.Rx;

public sealed class DisposableAction(Action action) : IDisposable
{
    public static DisposableAction Empty { get; } = new DisposableAction(() => { });
    private readonly Action _action = action ?? throw new ArgumentNullException(nameof(action));
    public void Dispose() => _action();
}
