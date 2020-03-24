using TelegramInterface.BaseTypes.Requests.Base;

namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to set a custom title for an administrator in a supergroup promoted by the bot. Returns True on success.
    /// </summary>
    public class SetChatAdministratorCustomTitle : BaseRequest
    {
        /// <summary>
        /// Required
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Required
        /// New custom title for the administrator; 0-16 characters, emoji are not allowed
        /// </summary>
        public string CustomTitle { get; set; }
    }
}
