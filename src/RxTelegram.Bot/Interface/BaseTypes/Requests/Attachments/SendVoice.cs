using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work,
    /// your audio must be in an .OGG file encoded with OPUS (other formats may be sent as Audio or Document). On success, the sent Message
    /// is returned. Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendVoice : BaseSend
    {
        /// <summary>
        /// Required
        /// Audio file to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL
        /// as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data.
        /// </summary>
        public InputFile Voice { get; set; }

        /// <summary>
        /// Optional
        /// Voice message caption, 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional
        /// Duration of the voice message in seconds
        /// </summary>
        public int? Duration { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
