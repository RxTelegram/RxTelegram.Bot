using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to get information about custom emoji stickers by their identifiers.
/// Returns an Array of Sticker objects.
/// </summary>
public class GetCustomEmojiStickers: BaseValidation
{
    /// <summary>
    /// List of custom emoji identifiers. At most 200 custom emoji identifiers can be specified.
    /// </summary>
    public Sticker[] CustomEmojiIds { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
