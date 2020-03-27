namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). By default, this animated MPEG-4 file will be sent by
    /// the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content
    /// instead of the animation.
    /// </summary>
    public class InlineQueryResultMpeg4Gif : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "mpeg4_gif";

        /// <summary>
        /// A valid URL for the MP4 file. File size must not exceed 1MB
        /// </summary>
        public string Mpeg4Url { get; set; }

        /// <summary>
        /// Optional. Video width
        /// </summary>
        public int? Mpeg4Width { get; set; }

        /// <summary>
        /// Optional. Video height
        /// </summary>
        public int? Mpeg4Height { get; set; }

        /// <summary>
        /// Optional. Video duration
        /// </summary>
        public int? Mpeg4Duration { get; set; }

        /// <summary>
        /// URL of the static thumbnail (jpeg or gif) for the result
        /// </summary>
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Optional. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public string ParseMode { get; set; }
    }
}
