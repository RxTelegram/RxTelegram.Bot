using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to set a new group sticker set for a supergroup. The bot must be an administrator in the chat for this to work and
/// must have the appropriate admin rights. Use the field can_set_sticker_set optionally returned in getChat requests to check if the
/// bot can use this method. Returns True on success.
/// </summary>
public class SetChatStickerSet : BaseRequest
{
    /// <summary>
    /// Required
    /// Name of the sticker set to be set as the group sticker set
    /// </summary>
    public string StickerSetName { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}