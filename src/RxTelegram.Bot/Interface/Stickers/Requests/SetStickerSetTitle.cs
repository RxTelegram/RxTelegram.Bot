using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to set the title of a created sticker set. Returns True on success.
/// </summary>
public class SetStickerSetTitle : BaseValidation
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Sticker set title, 1-64 characters
    /// </summary>
    public string Title { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
