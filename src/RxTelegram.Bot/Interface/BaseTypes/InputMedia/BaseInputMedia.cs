using System;
using System.IO;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia
{
    public abstract class BaseInputMedia
    {
        /// <summary>
        /// Type of the result
        /// </summary>
        public abstract string Type { get; set; }

        /// <summary>
        /// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://<file_attach_name>” to
        /// upload a new one using multipart/form-data under <file_attach_name> name.
        /// <see cref="https://core.telegram.org/bots/api#sending-files"/>»
        /// </summary>
        public InputFile Media { get; }

        public BaseInputMedia(string fileId) => Media = new InputFile(fileId);

        public BaseInputMedia(Uri uri) => Media = new InputFile(uri);

        public BaseInputMedia(Stream stream, string fileName = default) => Media = new InputFile(stream, fileName);
    }
}
