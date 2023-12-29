using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to get the list of boosts added to a chat by a user. Requires administrator rights in the chat.
/// Returns a <see cref="UserChatBoosts"/>  object.
/// </summary>
public class GetUserChatBoosts : BaseRequest
{
    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public long UserId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
