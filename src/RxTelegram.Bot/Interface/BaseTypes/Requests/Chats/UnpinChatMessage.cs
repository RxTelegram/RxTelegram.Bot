using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to unpin a message in a group, a supergroup, or a channel. The bot must be an administrator in the chat for this to
    /// work and must have the ‘can_pin_messages’ admin right in the supergroup or ‘can_edit_messages’ admin right in the channel.
    /// Returns True on success.
    /// </summary>
    public class UnpinChatMessage : BaseRequest
    {

    }
}
