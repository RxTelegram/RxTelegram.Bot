using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to set the thumbnail of a custom emoji sticker set. Returns True on success.
/// </summary>
public class SetCustomEmojiStickerSetThumbnail : BaseValidation
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Custom emoji identifier of a sticker from the sticker set;
    /// pass an empty string to drop the thumbnail and use the first sticker as the thumbnail.
    /// </summary>
    public string CustomEmojiId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
