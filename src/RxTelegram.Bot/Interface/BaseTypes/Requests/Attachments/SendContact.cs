using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
/// Use this method to send phone contacts. On success, the sent Message is returned.
/// </summary>
public class SendContact : BaseRequest, IProtectContent
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
    /// Contact's phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Required
    /// Contact's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Optional
    /// Contact's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Optional
    /// Additional data about the contact in the form of a vCard, 0-2048 bytes
    /// </summary>
    public string Vcard { get; set; }

    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
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
