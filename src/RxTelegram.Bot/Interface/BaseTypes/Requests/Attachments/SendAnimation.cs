using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    ///     Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound). On success, the sent Message is returned.
    ///     Bots can currently send animation files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendAnimation : BaseSend
    {
        /// <summary>
        ///     Required
        ///     Animation to send. Pass a file_id as String to send an animation that exists on the Telegram servers (recommended), pass an
        ///     HTTP URL as a String for Telegram to get an animation from the Internet, or upload a new animation using multipart/form-data.
        /// </summary>
        public InputFile Animation { get; set; }

        /// <summary>
        ///     Optional
        ///     Duration of sent animation in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        ///     Optional
        ///     Animation width
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        ///     Optional
        ///     Animation height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        ///     Optional
        ///     Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail
        ///     should be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the
        ///     file is not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you
        ///     can pass “attach://{file_attach_name}” if the thumbnail was uploaded using multipart/form-data under {file_attach_name}.
        /// </summary>
        public InputFile Thumb { get; set; }

        /// <summary>
        ///     Optional
        ///     Animation caption (may also be used when resending animation by file_id), 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
