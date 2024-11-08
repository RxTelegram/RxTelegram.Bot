using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
/// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work,
/// your audio must be in an .OGG file encoded with OPUS (other formats may be sent as Audio or Document). On success, the sent Message
/// is returned. Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
/// </summary>
public class SendVoice : BaseSend, IProtectContent, IAllowPaidBroadcast
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
    /// Audio file to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL
    /// as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data.
    /// </summary>
    public InputFile Voice { get; set; }

    /// <summary>
    /// Optional
    /// Voice message caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional
    /// Duration of the voice message in seconds
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message.
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool? AllowPaidBroadcast { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
