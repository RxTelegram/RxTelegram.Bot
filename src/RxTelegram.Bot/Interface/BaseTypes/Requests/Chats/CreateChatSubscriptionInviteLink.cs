using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to create a subscription invite link for a channel chat.
/// The bot must have the can_invite_users administrator rights.
/// The link can be edited using the method editChatSubscriptionInviteLink or revoked using the method <see cref="RevokeChatInviteLink"/>.
/// Returns the new invite link as a ChatInviteLink object.
/// </summary>
public class CreateChatSubscriptionInviteLink : BaseRequest
{
    /// <summary>
    /// Invite link name; 0-32 characters
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The number of seconds the subscription will be active for before the next payment. Currently, it must always be 2592000 (30 days).
    /// </summary>
    public int SubscriptionPeriod { get; set; }

    /// <summary>
    /// The amount of Telegram Stars a user must pay initially and after each subsequent subscription period to be a member of the chat; 1-2500
    /// </summary>
    public int SubscriptionPrice { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
