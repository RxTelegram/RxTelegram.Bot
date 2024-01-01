using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about a chat boost.
/// </summary>
public class ChatBoost
{
    /// <summary>
    /// Unique identifier of the boost
    /// </summary>
    public string BoostId { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when the chat was boosted
    /// </summary>
    public DateTime AddDate { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when the boost will automatically expire, unless the booster's Telegram Premium subscription is prolonged
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Source of the added boost
    /// </summary>
    public ChatBoostSource Source { get; set; }
}
