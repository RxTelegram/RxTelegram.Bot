using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to kick a user from a group, a supergroup or a channel. In the case of supergroups and channels, the user will not
    /// be able to return to the group on their own using invite links, etc., unless unbanned first. The bot must be an administrator in
    /// the chat for this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class BanChatMember : BaseRequest
    {
        /// <summary>
        /// Required
        /// Unique identifier of the target user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Optional
        /// Date when the user will be unbanned, unix time. If user is banned for more than 366 days or less than 30 seconds from the
        /// current time they are considered to be banned forever
        /// </summary>
        public int UntilDate { get; set; }

        /// <summary>
        /// Optional
        /// Pass True to delete all messages from the chat for the user that is being removed.
        /// If False, the user will be able to see messages in the group that were sent before the user was removed.
        /// Always True for supergroups and channels.
        /// </summary>
        public bool? RevokeMessages { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
