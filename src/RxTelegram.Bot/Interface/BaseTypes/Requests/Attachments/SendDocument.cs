using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendDocument : BaseSend
    {
        /// <summary>
        /// File to send
        /// </summary>
        public InputFile Document { get; set; }

        /// <summary>
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320
        /// </summary>
        public InputFile Thumb { get; set; }

        /// <summary>
        /// Document caption (may also be used when resending documents by file_id), 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
