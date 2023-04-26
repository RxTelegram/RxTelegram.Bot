using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to change the mask position of a mask sticker. The sticker must belong to a sticker set that was created by the bot.
/// Returns True on success.
/// </summary>
public class SetStickerMaskPosition : BaseValidation
{
    /// <summary>
    /// File identifier of the sticker
    /// </summary>
    public string Sticker { get; set; }

    /// <summary>
    /// A JSON-serialized object with the position where the mask should be placed on faces. Omit the parameter to remove the mask position.
    /// </summary>
    public MaskPosition MaskPosition { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
