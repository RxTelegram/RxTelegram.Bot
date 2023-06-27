using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to pin a message in a group, a supergroup, or a channel. The bot must be an administrator in the chat for this to
/// work and must have the ‘can_pin_messages’ admin right in the supergroup or ‘can_edit_messages’ admin right in the channel.
/// Returns True on success.
/// </summary>
public class PinChatMessage : BaseRequest
{
    /// <summary>
    /// Required
    /// Identifier of a message to pin
    /// </summary>
    public int MessageId { get; set; }

    /// <summary>
    /// Pass True, if it is not necessary to send a notification to all chat members about the new pinned message.
    /// Notifications are always disabled in channels.
    /// </summary>
    public bool DisableNotification { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}