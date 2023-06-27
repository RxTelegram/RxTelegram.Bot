using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to decline a chat join request.
/// The bot must be an administrator in the chat for this to work and must have the can_invite_users administrator right.
/// </summary>
public class DeclineChatJoinRequest : BaseRequest
{
    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public long UserId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
