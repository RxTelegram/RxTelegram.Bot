namespace TelegramInterface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a file stored on the Telegram servers. By default, this file will be sent by the user with an optional caption.
    /// Alternatively, you can use input_message_content to send a message with the specified content instead of the file.
    /// </summary>
    public class InlineQueryResultCachedDocument : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "document";

        /// <summary>
        /// A valid file identifier for the file
        /// </summary>
        public string DocumentFileId { get; set; }

        /// <summary>
        /// Optional.
        /// Short description of the result
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional.
        /// Caption of the document to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public string ParseMode { get; set; }
    }
}
