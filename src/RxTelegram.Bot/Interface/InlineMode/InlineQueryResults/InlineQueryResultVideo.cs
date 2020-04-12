using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a page containing an embedded video player or a video file. By default, this video file will be sent by the
    /// user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content
    /// instead of the video.
    ///
    /// If an InlineQueryResultVideo message contains an embedded video (e.g., YouTube), you must replace its content using
    /// input_message_content.
    /// </summary>
    public class InlineQueryResultVideo : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "video";

        /// <summary>
        /// A valid URL for the embedded video player or video file
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Mime type of the content of video url, “text/html” or “video/mp4”
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// URL of the thumbnail (jpeg only) for the video
        /// </summary>
        public string ThumbUrl { get; set; }

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

        /// <summary>
        /// Optional.
        /// Video width
        /// </summary>
        public int? VideoWidth { get; set; }

        /// <summary>
        /// Optional.
        /// Video height
        /// </summary>
        public int? VideoHeight { get; set; }

        /// <summary>
        /// Optional.
        /// Video duration in seconds
        /// </summary>
        public int? VideoDuration { get; set; }

        /// <summary>
        /// Optional. Short description of the result
        /// </summary>
        public string Description { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
