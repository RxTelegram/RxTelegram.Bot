namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a voice message stored on the Telegram servers. By default, this voice message will be sent by the user.
    /// Alternatively, you can use input_message_content to send a message with the specified content instead of the voice message.
    /// </summary>
    public class InlineQueryResultCachedVoice : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "voice";

        /// <summary>
        /// A valid file identifier for the voice message
        /// </summary>
        public string VoiceFileId { get; set; }

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
