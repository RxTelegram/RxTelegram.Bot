using System;
using System.IO;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class InputFile
    {
        public InputFile(string fileId) => Value = fileId;

        public InputFile(Uri uri) => Value = uri.AbsoluteUri;

        public InputFile(Stream stream, string fileName = default)
        {
            Stream = stream;
            FileName = fileName;
        }

        public string Value { get; }

        public string FileName { get; }

        public Stream Stream { get; }

        public static implicit operator InputFile(Stream stream) => new InputFile(stream);

        public static implicit operator InputFile(Uri uri) => new InputFile(uri);

        public static implicit operator InputFile(string fileId) => new InputFile(fileId);
    }
}
