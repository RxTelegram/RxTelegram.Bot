using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to send static .WEBP or animated .TGS stickers. On success, the sent Message is returned.
/// </summary>
public class SendSticker : BaseValidation, IProtectContent
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
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public ChatId ChatId { get; set; }

    /// <summary>
    /// Required
    /// Sticker to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL
    /// as a String for Telegram to get a .WEBP file from the Internet, or upload a new one using multipart/form-data.
    /// </summary>
    public InputFile Sticker { get; set; }

    /// <summary>
    /// Emoji associated with the sticker; only for just uploaded stickers
    /// </summary>
    public string Emoji { get; set; }

    /// <summary>
    /// Optional
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool DisableNotification { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// Optional
    /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove
    /// reply keyboard or to force a reply from the user.
    /// </summary>
    public IReplyMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
