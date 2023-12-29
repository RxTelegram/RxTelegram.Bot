using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Reaction;

/// <summary>
/// This object represents a change of a reaction on a message performed by a user.
/// </summary>
public class MessageReactionUpdated
{
    /// <summary>
    /// The chat containing the message the user reacted to
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Unique identifier of the message inside the chat
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Optional. The user that changed the reaction, if the user isn't anonymous
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Optional. The chat on behalf of which the reaction was changed, if the user is anonymous
    /// </summary>
    public Chat ActorChat { get; set; }

    /// <summary>
    /// Date of the change in Unix timestamp format
    /// </summary>
    public long Date { get; set; }

    /// <summary>
    /// Previous list of reaction types that were set by the user
    /// </summary>
    public Enums.ReactionType[] OldReaction { get; set; }

    /// <summary>
    /// New list of reaction types that have been set by the user
    /// </summary>
    public Enums.ReactionType[] NewReaction { get; set; }
}
