using System;
namespace RxTelegram.Bot.Utils.Rx;

sealed public class DisposableAction : IDisposable
{
  private readonly Action action;

  public DisposableAction(Action action)
  {
    if (action == null)
      throw new ArgumentNullException(nameof(action));
    this.action = action;
  }

  public void Dispose() => action();
}
