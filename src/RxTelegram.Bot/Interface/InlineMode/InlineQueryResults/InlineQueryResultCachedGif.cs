using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to an animated GIF file stored on the Telegram servers. By default, this animated GIF file will be sent by the
/// user with an optional caption. Alternatively, you can use input_message_content to send a message with specified content instead
/// of the animation.
/// </summary>
public class InlineQueryResultCachedGif : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "gif";

    /// <summary>
    /// A valid URL for the GIF file. File size must not exceed 1MB
    /// </summary>
    public string GifFileId { get; set; }


    /// <summary>
    /// Optional.
    /// Caption of the GIF file to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    /// fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// Optional. True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
