using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound) stored on the Telegram servers. By default, this
    /// animated MPEG-4 file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a
    /// message with the specified content instead of the animation.
    /// </summary>
    public class InlineQueryResultCachedMpeg4Gif : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "mpeg4_gif";

        /// <summary>
        /// A valid file identifier for the MP4 file
        /// </summary>
        public string Mpeg4FileId { get; set; }

        /// <summary>
        /// Optional.
        /// Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public ParseMode ParseMode { get; set; }
    }
}
