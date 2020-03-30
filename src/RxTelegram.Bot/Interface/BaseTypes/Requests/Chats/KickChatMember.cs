using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to kick a user from a group, a supergroup or a channel. In the case of supergroups and channels, the user will not
    /// be able to return to the group on their own using invite links, etc., unless unbanned first. The bot must be an administrator in
    /// the chat for this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class KickChatMember : BaseRequest
    {
        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Date when the user will be unbanned, unix time. If user is banned for more than 366 days or less than 30 seconds from the
        /// current time they are considered to be banned forever
        /// </summary>
        public int UntilDate { get; set; }

    }
}
