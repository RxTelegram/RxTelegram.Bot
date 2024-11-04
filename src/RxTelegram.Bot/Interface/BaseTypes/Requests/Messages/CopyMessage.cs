using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to copy messages of any kind. The method is analogous to the method forwardMessages,
/// but the copied message doesn't have a link to the original message. Returns the MessageId of the sent message on success.
/// </summary>
public class CopyMessage : BaseSend, IProtectContent, IAllowPaidBroadcast
{
    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername)
    /// </summary>
    public ChatId FromChatId { get; set; }

    /// <summary>
    /// Message identifier in the chat specified in from_chat_id
    /// </summary>
    public int MessageId { get; set; }

    /// <summary>
    /// Optional
    /// New caption for media, 0-1024 characters after entities parsing. If not specified, the original caption is kept
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional
    /// A JSON-serialized list of special entities that appear in the new caption, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional
    /// Pass True, if the message should be sent even if the specified replied-to message is not found
    /// </summary>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// Optional. True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message.
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool? AllowPaidBroadcast { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
