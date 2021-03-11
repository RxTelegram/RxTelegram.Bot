using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to revoke an invite link created by the bot. If the primary link is revoked, a new link is automatically generated.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    public class RevokeChatInviteLink : BaseRequest
    {
        /// <summary>
        /// The invite link to revoke
        /// </summary>
        public string InviteLink { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
