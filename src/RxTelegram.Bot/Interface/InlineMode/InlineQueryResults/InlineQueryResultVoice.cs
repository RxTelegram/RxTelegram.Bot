using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a voice recording in an .OGG container encoded with OPUS. By default, this voice recording will be sent by the
    /// user. Alternatively, you can use input_message_content to send a message with the specified content instead of the the voice message.
    /// </summary>
    public class InlineQueryResultVoice : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "voice";

        /// <summary>
        /// A valid URL for the voice recording
        /// </summary>
        public string VoiceUrl { get; set; }

        /// <summary>
        /// Optional.
        /// Recording duration in seconds
        /// </summary>
        public int? VoiceDuration { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public ParseMode ParseMode { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
