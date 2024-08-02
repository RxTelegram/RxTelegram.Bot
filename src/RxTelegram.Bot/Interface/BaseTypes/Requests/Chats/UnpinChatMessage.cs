using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to unpin a message in a group, a supergroup, or a channel. The bot must be an administrator in the chat for this to
/// work and must have the ‘can_pin_messages’ admin right in the supergroup or ‘can_edit_messages’ admin right in the channel.
/// Returns True on success.
/// </summary>
public class UnpinChatMessage : BaseRequest
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be pinned
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Identifier of a message to unpin. If not specified, the most recent pinned message (by sending date) will be unpinned.
    /// </summary>
    public int? MessageId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
