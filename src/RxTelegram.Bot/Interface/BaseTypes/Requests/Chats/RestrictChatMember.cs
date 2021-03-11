using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to restrict a user in a supergroup. The bot must be an administrator in the supergroup for this to work and must
    /// have the appropriate admin rights. Pass True for all permissions to lift restrictions from a user. Returns True on success.
    /// </summary>
    public class RestrictChatMember : BaseRequest
    {
        /// <summary>
        /// Required
        /// Unique identifier of the target user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Required
        /// New user permissions
        /// </summary>
        public ChatPermissions Permissions { get; set; }

        /// <summary>
        /// Date when restrictions will be lifted for the user, unix time. If user is restricted for more than 366 days or less than 30
        /// seconds from the current time, they are considered to be restricted forever
        /// </summary>
        public int UntilDate { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
