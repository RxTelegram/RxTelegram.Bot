using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Reaction.Requests;

/// <summary>
/// Use this method to change the chosen reactions on a message.
/// Service messages can't be reacted to.
/// Automatically forwarded messages from a channel to its discussion group have the same available reactions as messages in the channel.
/// In albums, bots must react to the first message.
/// Returns True on success.
/// </summary>
public class SetMessageReaction : BaseRequest
{
    /// <summary>
    /// Identifier of the target message
    /// </summary>
    public int MessageId { get; set; }

    /// <summary>
    /// New list of reaction types to set on the message.
    /// Currently, as non-premium users, bots can set up to one reaction per message.
    /// A custom emoji reaction can be used if it is either already present on the message or explicitly allowed by chat administrators.
    /// </summary>
    public ReactionType[] Reaction { get; set; }

    /// <summary>
    /// Pass True to set the reaction with a big animation
    /// </summary>
    public bool IsBig { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
