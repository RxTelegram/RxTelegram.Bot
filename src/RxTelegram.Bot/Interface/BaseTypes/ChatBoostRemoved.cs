using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a boost removed from a chat.
/// </summary>
public class ChatBoostRemoved
{
    /// <summary>
    /// Chat which was boosted
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Unique identifier of the boost
    /// </summary>
    public string BoostId { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when the boost was removed
    /// </summary>
    public DateTime RemoveDate { get; set; }

    /// <summary>
    /// Source of the removed boost
    /// </summary>
    public ChatBoostSource Source { get; set; }
}
