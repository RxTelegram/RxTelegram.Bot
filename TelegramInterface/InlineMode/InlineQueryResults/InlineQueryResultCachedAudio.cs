namespace TelegramInterface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to an MP3 audio file stored on the Telegram servers. By default, this audio file will be sent by the user.
    /// Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
    /// </summary>
    public class InlineQueryResultCachedAudio : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "audio";

        /// <summary>
        /// A valid file identifier for the audio file
        /// </summary>
        public string AudioFileId { get; set; }

        /// <summary>
        /// Optional.
        /// Caption, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public string ParseMode { get; set; }
    }
}
