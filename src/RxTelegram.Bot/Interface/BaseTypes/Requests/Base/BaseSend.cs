using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

public abstract class BaseSend : BaseTextRequest
{
    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// If the message is a reply, ID of the original message
    /// </summary>
    public int? ReplyToMessageId { get; set; }

    /// <summary>
    /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
    /// </summary>
    public IReplyMarkup ReplyMarkup { get; set; }
}
