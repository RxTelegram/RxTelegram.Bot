namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;

public interface IAllowPaidBroadcast
{
    /// <summary>
    /// Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message.
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool? AllowPaidBroadcast { get; set; }
}
