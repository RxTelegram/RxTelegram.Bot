using System.Collections.Generic;
using RxTelegram.Bot.Interface.Stickers.Enums;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
///     Use this method to create new sticker set owned by a user. The bot will be able to edit the created sticker set.
///     Returns True on success.
/// </summary>
public class CreateNewStickerSet : BaseValidation
{
    /// <summary>
    /// Required
    /// User identifier of created sticker set owner
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Required
    /// Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals). Can contain only english letters, digits and
    /// underscores. Must begin with a letter, can't contain consecutive underscores and must end in “_by_{bot username}”.
    /// {bot_username} is case insensitive. 1-64 characters.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Required
    /// Sticker set title, 1-64 characters
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// A JSON-serialized list of 1-50 initial stickers to be added to the sticker set
    /// </summary>
    public List<InputSticker> Stickers { get; set; }

    /// <summary>
    /// Format of stickers in the set, must be one of “static”, “animated”, “video”
    /// </summary>
    public StickerFormat StickerFormat { get; set; }

    /// <summary>
    /// Type of stickers in the set, pass “regular” or “mask”.
    /// Custom emoji sticker sets can't be created via the Bot API at the moment.
    /// By default, a regular sticker set is created.
    /// </summary>
    public StickerType? StickerType { get; set; }

    /// <summary>
    /// Pass True if stickers in the sticker set must be repainted to the color of text when used in messages,
    /// the accent color if used as emoji status, white on chat photos, or another appropriate color based on context;
    /// for custom emoji sticker sets only
    /// </summary>
    public bool? NeedsRepainting { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
