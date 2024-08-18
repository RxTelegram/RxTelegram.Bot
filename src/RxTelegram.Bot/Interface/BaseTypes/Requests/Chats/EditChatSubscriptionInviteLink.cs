using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to edit a subscription invite link created by the bot. The bot must have the can_invite_users administrator rights.
/// </summary>
public class EditChatSubscriptionInviteLink : BaseRequest
{
    /// <summary>
    /// The invite link to edit
    /// </summary>
    public string InviteLink { get; set; }

    /// <summary>
    /// Invite link name; 0-32 characters
    /// </summary>
    public string Name { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
