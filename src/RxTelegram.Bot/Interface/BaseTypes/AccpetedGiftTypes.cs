namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object describes the types of gifts that can be gifted to a user or a chat.
/// </summary>
public class AccpetedGiftTypes
{
    /// <summary>
    /// True, if unlimited regular gifts are accepted
    /// </summary>
    public bool UnlimitedGifts { get; set; }

    /// <summary>
    /// True, if limited regular gifts are accepted
    /// </summary>
    public bool LimitedGifts { get; set; }

    /// <summary>
    /// True, if unique gifts or gifts that can be upgraded to unique for free are accepted
    /// </summary>
    public bool UniqueGifts { get; set; }

    /// <summary>
    /// True, if a Telegram Premium subscription is accepted
    /// </summary>
    public bool PremiumSubscription { get; set; }
}
