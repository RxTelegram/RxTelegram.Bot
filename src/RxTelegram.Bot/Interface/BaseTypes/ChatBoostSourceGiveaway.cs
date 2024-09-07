using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The boost was obtained by the creation of a Telegram Premium giveaway.
/// This boosts the chat 4 times for the duration of the corresponding Telegram Premium subscription.
/// </summary>
public class ChatBoostSourceGiveaway : ChatBoostSource
{
    /// <summary>
    /// Source of the boost, always “giveaway”
    /// </summary>
    public override ChatBoostSourceType Source { get; set; } = ChatBoostSourceType.Giveaway;

    /// <summary>
    /// Identifier of a message in the chat with the giveaway; the message could have been deleted already.
    /// May be 0 if the message isn't sent yet.
    /// </summary>
    public long GiveawayMessageId { get; set; }

    /// <summary>
    /// Optional. User that won the prize in the giveaway if any
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Optional. The number of Telegram Stars to be split between giveaway winners; for Telegram Star giveaways only
    /// </summary>
    public int PrizeStarCount { get; set; }

    /// <summary>
    /// Optional. True, if the giveaway was completed, but there was no user to win the prize
    /// </summary>
    public bool IsUnclaimed { get; set; }
}
