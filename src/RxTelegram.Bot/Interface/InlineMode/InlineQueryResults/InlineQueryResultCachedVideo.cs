using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to a video file stored on the Telegram servers. By default, this video file will be sent by the user with an
/// optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the video.
/// </summary>
public class InlineQueryResultCachedVideo : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "video";

    /// <summary>
    /// A valid file identifier for the video file
    /// </summary>
    public string VideoFileId { get; set; }

    /// <summary>
    /// Optional.
    /// Caption of the video to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    /// fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}