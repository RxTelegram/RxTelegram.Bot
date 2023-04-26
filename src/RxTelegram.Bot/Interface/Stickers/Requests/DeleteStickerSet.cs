using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to delete a sticker set that was created by the bot. Returns True on success.
/// </summary>
public class DeleteStickerSet : BaseValidation
{
    public string Name { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
