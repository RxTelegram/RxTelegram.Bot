using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to set default chat permissions for all members. The bot must be an administrator in the group or a supergroup for
    /// this to work and must have the can_restrict_members admin rights. Returns True on success.
    /// </summary>
    public class SetChatPermissions : BaseRequest
    {
        /// <summary>
        /// New default chat permissions
        /// </summary>
        public ChatPermissions Permissions { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
