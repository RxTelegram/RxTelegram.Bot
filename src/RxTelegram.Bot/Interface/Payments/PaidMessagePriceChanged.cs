namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a service message about a change in the price of paid messages within a chat.
/// </summary>
public class PaidMessagePriceChanged
{
    /// <summary>
    /// The new number of Telegram Stars that must be paid by non-administrator users of the supergroup chat for each sent message
    /// </summary>
    public long PaidMessageStarCount { get; set; }
}
