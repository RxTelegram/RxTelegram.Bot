using TelegramInterface.BaseTypes.Requests.Attachments;

namespace TelegramInterface.BaseTypes.InputMedia
{
    public class InputMediaAnimation : BaseInputMedia
    {
        /// <summary>
        /// Type of the result, must be animation
        /// </summary>
        public override string Type { get; set; } = "animation";

        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size.
        /// A thumbnail‘s width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data.
        /// Thumbnails can’t be reused and can be only uploaded as a new file, so you can pass “attach://<file_attach_name>” if
        /// the thumbnail was uploaded using multipart/form-data under <file_attach_name>.
        /// <see cref="https://core.telegram.org/bots/api#sending-files"/>
        /// </summary>
        public InputFile Thumb { get; set; }

        /// <summary>
        /// Optional. Caption of the video to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in the media caption.
        /// </summary>
        public string ParseMode { get; set; }

        /// <summary>
        /// Optional. Video width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Optional. Video height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Optional. Video duration
        /// </summary>
        public int Duration { get; set; }
    }
}
