using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to unban a previously kicked user in a supergroup or channel. The user will not return to the group or channel
    /// automatically, but will be able to join via link, etc. The bot must be an administrator for this to work. Returns True on success.
    /// </summary>
    public class UnbanChatMember : BaseRequest
    {
        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }
    }
}
