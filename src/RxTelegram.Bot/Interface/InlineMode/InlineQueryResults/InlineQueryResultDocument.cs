using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to a file. By default, this file will be sent by the user with an optional caption. Alternatively, you can use
/// input_message_content to send a message with the specified content instead of the file. Currently, only .PDF and .ZIP files can be
/// sent using this method.
/// </summary>
public class InlineQueryResultDocument : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "document";

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    /// fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// Optional.
    /// Caption of the document to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// A valid URL for the file
    /// </summary>
    public string DocumentUrl { get; set; }

    /// <summary>
    /// Mime type of the content of the file, either “application/pdf” or “application/zip”
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// Optional.
    /// Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional.
    /// URL of the thumbnail (jpeg only) for the file
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional.
    /// Thumbnail width
    /// </summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional.
    /// Thumbnail height
    /// </summary>
    public int? ThumbnailHeight { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}