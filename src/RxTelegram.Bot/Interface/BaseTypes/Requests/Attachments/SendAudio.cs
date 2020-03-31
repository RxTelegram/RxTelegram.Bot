using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to send audio files, if you want Telegram clients to display them in the music player. Your audio must be in the
    /// .MP3 or .M4A format. On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this
    /// limit may be changed in the future.
    /// For sending voice messages, use the sendVoice method instead.
    /// </summary>
    public class SendAudio : BaseSend
    {
        /// <summary>
        /// Required
        /// Audio file to send. Pass a file_id as String to send an audio file that exists on the Telegram servers (recommended), pass
        /// an HTTP URL as a String for Telegram to get an audio file from the Internet, or upload a new one using multipart/form-data.
        /// </summary>
        public InputFile Audio { get; set; }

        /// <summary>
        /// Optional
        /// Audio caption, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional
        /// Duration of the audio in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Optional
        /// Performer
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// Optional
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Optional
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail
        /// should be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the
        /// file is not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you
        /// can pass “attach://<file_attach_name>” if the thumbnail was uploaded using multipart/form-data under <file_attach_name>.
        /// </summary>
        public InputFile Thumb { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
