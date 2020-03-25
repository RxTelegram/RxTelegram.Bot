using TelegramInterface.BaseTypes.Requests.Base;

namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to get information about a member of a chat. Returns a ChatMember object on success.
    /// </summary>
    public class GetChatMember : BaseRequest
    {
        public int UserId { get; set; }
    }
}
