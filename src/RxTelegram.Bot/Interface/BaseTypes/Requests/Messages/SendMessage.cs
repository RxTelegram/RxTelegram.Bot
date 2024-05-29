using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

public class SendMessage : BaseTextRequest, IProtectContent
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Required
    /// Text of the message to be sent, 1-4096 characters after entities parsing
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Link preview generation options for the message
    /// </summary>
    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    /// <summary>
    /// Optional
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// Optional
    /// Additional interface options. A JSON-serialized object for an inline keyboard,
    /// custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
    /// </summary>
    public IReplyMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// List of special entities that appear in message text, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> Entities { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
