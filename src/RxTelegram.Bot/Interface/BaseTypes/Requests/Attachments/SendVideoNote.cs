using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    ///     As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long. Use this method to send video messages.
    ///     On success, the sent Message is returned.
    /// </summary>
    public class SendVideoNote : BaseSend, IProtectContent
    {
        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public int MessageThreadId { get; set; }

        /// <summary>
        ///     Required
        ///     Video note to send. Pass a file_id as String to send a video note that exists on the Telegram servers (recommended) or
        ///     upload a new video using multipart/form-data.
        ///     !!! Sending video notes by a URL is currently unsupported !!!
        /// </summary>
        public InputFile VideoNote { get; set; }

        /// <summary>
        ///     Optional
        ///     Duration of sent video in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        ///     Optional
        ///     Video width and height, i.e. diameter of the video message
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        ///     Optional
        ///     Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should
        ///     be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the file is
        ///     not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you can pass
        ///     “attach://{file_attach_name}” if the thumbnail was uploaded using multipart/form-data under {file_attach_name}.
        /// </summary>
        public InputFile Thumb { get; set; }

        /// <summary>
        /// Pass True, if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
