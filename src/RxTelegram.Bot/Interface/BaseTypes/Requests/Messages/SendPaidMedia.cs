using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to send paid media to channel chats. On success, the sent Message is returned.
/// </summary>
public class SendPaidMedia : BaseTextRequest, IAllowPaidBroadcast
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// The number of Telegram Stars that must be paid to buy access to the media
    /// </summary>
    public int StarCount { get; set; }

    /// <summary>
    /// A JSON-serialized array describing the media to be sent; up to 10 items
    /// </summary>
    public List<BaseInputPaidMedia> Media { get; set; }

    /// <summary>
    /// Bot-defined paid media payload, 0-128 bytes. This will not be displayed to the user, use it for your internal processes.
    /// </summary>
    public string Payload { get; set; }

    /// <summary>
    /// Media caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// A JSON-serialized list of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool DisableNotification { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool ProtectContent { get; set; }


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
    /// Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message.
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool? AllowPaidBroadcast { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
