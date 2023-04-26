using System.Collections.Generic;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to change search keywords assigned to a regular or custom emoji sticker.
/// The sticker must belong to a sticker set created by the bot. Returns True on success.
/// </summary>
public class SetStickerKeywords : BaseValidation
{
    /// <summary>
    /// File identifier of the sticker
    /// </summary>
    public string Sticker { get; set; }

    /// <summary>
    /// A JSON-serialized list of 0-20 search keywords for the sticker with total length of up to 64 characters
    /// </summary>
    public List<string> Keywords { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
