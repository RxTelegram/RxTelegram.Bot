using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to unban a previously banned channel chat in a supergroup or channel.
/// The bot must be an administrator for this to work and must have the appropriate administrator rights.
/// Returns True on success.
/// </summary>
public class UnbanChatSenderChat : BaseRequest
{
    /// <summary>
    /// Unique identifier of the target sender chat
    /// </summary>
    public int SenderChatId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
