using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Marks incoming message as read on behalf of a business account. Requires the can_read_messages business bot right. Returns True on success.
/// </summary>
public class ReadBusinessMessage : BaseBusinessRequest
{
    /// <summary>
    /// Required
    /// Unique identifier of the chat in which the message was received. The chat must have been active in the last 24 hours.
    /// </summary>
    public ChatId ChatId { get; set; }

    /// <summary>
    /// Required
    /// Unique identifier of the message to mark as read
    /// </summary>
    public int MessageId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
