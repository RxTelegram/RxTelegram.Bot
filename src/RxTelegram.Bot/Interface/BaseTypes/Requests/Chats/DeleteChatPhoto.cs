using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to delete a chat photo. Photos can't be changed for private chats. The bot must be an administrator in the chat for
    /// this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class DeleteChatPhoto : BaseRequest
    {

    }
}
