using TelegramInterface.BaseTypes.Requests.Base;

namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to delete a group sticker set from a supergroup. The bot must be an administrator in the chat for this to work and
    /// must have the appropriate admin rights. Use the field can_set_sticker_set optionally returned in getChat requests to check if the
    /// bot can use this method. Returns True on success.
    /// </summary>
    public class DeleteChatStickerSet : BaseRequest
    {

    }
}
