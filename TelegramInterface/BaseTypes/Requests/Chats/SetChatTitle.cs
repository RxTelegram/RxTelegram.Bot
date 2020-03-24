using TelegramInterface.BaseTypes.Requests.Base;

namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to change the title of a chat. Titles can't be changed for private chats. The bot must be an administrator in the
    /// chat for this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class SetChatTitle : BaseRequest
    {
        /// <summary>
        /// Required
        /// New chat title, 1-255 characters
        /// </summary>
        public string Title { get; set; }
    }
}
