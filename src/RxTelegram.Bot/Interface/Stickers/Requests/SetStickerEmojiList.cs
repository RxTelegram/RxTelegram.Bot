using System.Collections.Generic;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Use this method to change the list of emoji assigned to a regular or custom emoji sticker.
/// The sticker must belong to a sticker set created by the bot.
/// Returns True on success.
/// </summary>
public class SetStickerEmojiList : BaseValidation
{
    /// <summary>
    /// File identifier of the sticker
    /// </summary>
    public string Sticker { get; set; }

    /// <summary>
    /// A JSON-serialized list of 1-20 emoji associated with the sticker
    /// </summary>
    public List<string> EmojiList { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
