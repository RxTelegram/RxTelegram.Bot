using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to replace an existing sticker in a sticker set with a new one.
/// The method is equivalent to calling <see cref="ITelegramBot.DeleteStickerFromSet"/>, then <see cref="ITelegramBot.AddStickerToSet"/>, then <see cref="ITelegramBot.SetStickerPositionInSet"/>.
/// Returns True on success.
/// </summary>
public class ReplaceStickerInSet : BaseValidation
{
    /// <summary>
    /// User identifier of the sticker set owner
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// File identifier of the replaced sticker
    /// </summary>
    public string OldSticker { get; set; }

    /// <summary>
    /// A JSON-serialized object with information about the added sticker.
    /// If exactly the same sticker had already been added to the set, then the set remains unchanged.
    /// </summary>
    public InputSticker Sticker { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
