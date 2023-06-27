using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to move a sticker in a set created by the bot to a specific position. Returns True on success.
/// </summary>
public class SetStickerPositionInSet : BaseValidation
{
    /// <summary>
    /// Required
    /// File identifier of the sticker
    /// </summary>
    public string Sticker { get; set; }

    /// <summary>
    /// Required
    /// New sticker position in the set, zero-based
    /// </summary>
    public int Position { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
