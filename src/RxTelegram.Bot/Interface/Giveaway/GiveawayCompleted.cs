using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Giveaway;

/// <summary>
/// This object represents a service message about the completion of a giveaway without public winners.
/// </summary>
public class GiveawayCompleted
{
    /// <summary>
    /// Number of winners in the giveaway
    /// </summary>
    public int WinnerCount { get; set; }

    /// <summary>
    /// Optional. Number of undistributed prizes
    /// </summary>
    public int UnclaimedPrizeCount { get; set; }

    /// <summary>
    /// Optional. Message with the giveaway that was completed, if it wasn't deleted
    /// </summary>
    public Message GiveawayMessage { get; set; }

    /// <summary>
    /// Optional. True, if the giveaway is a Telegram Star giveaway. Otherwise, currently, the giveaway is a Telegram Premium giveaway.
    /// </summary>
    public bool IsStarGiveaway { get; set; }
}
