using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

public class SendMediaGroup : BaseRequest, IProtectContent
{
    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// A JSON-serialized array describing photos and videos to be sent, must include 2–10 items
    /// </summary>
    public IEnumerable<BaseInputMedia> Media { get; set; }

    /// <summary>
    /// Sends the messages silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// If the messages are a reply, ID of the original message
    /// </summary>
    public int? ReplyToMessageId { get; set; }

    /// <summary>
    /// Pass True, if the message should be sent even if the specified replied-to message is not found
    /// </summary>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}