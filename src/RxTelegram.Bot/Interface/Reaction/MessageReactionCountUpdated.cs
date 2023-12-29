using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Reaction;

/// <summary>
/// This object represents reaction changes on a message with anonymous reactions.
/// </summary>
public class MessageReactionCountUpdated
{
    /// <summary>
    /// The chat containing the message
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Unique message identifier inside the chat
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Date of the change in Unix timestamp format
    /// </summary>
    public int Date { get; set; }

    /// <summary>
    /// List of reactions that are present on the message
    /// </summary>
    public ReactionCount[] Reactions { get; set; }
}
