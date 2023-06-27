using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.Stickers.Enums;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

public class UploadStickerFile : BaseValidation
{
    /// <summary>
    /// Required
    /// User identifier of sticker file owner
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format. See https://core.telegram.org/stickers for technical requirements.
    /// </summary>
    public InputFile Sticker { get; set; }

    /// <summary>
    /// Format of the sticker, must be one of “static”, “animated”, “video”
    /// </summary>
    public StickerFormat StickerFormat { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
