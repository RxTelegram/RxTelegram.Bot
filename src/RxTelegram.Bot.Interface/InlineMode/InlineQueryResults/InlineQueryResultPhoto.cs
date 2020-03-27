namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a photo. By default, this photo will be sent by the user with optional caption.
    /// Alternatively, you can use input_message_content to send a message with the specified content instead of the photo.
    /// </summary>
    public class InlineQueryResultPhoto : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "photo";

        /// <summary>
        /// A valid URL of the photo. Photo must be in jpeg format. Photo size must not exceed 5MB
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// URL of the thumbnail for the photo
        /// </summary>
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Optional.
        /// Width of the photo
        /// </summary>
        public int PhotoWidth { get; set; }

        /// <summary>
        /// Optional. Height of the photo
        /// </summary>
        public int PhotoHeight { get; set; }

        /// <summary>
        /// Optional.
        /// Short description of the result
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional.
        /// Caption of the photo to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public string ParseMode { get; set; }
    }
}
