using System;
using System.IO;

namespace TelegramInterface.BaseTypes.Requests.Attachments
{
    public class InputFile
    {
        public string Value { get; }

        public string FileName { get; }

        public Stream Stream { get; }

        public InputFile(string fileId)
        {
            Value = fileId;
        }

        public InputFile(Uri uri)
        {
            Value = uri.AbsolutePath;
        }

        public InputFile(Stream stream, string fileName = default)
        {
            Stream = stream;
            FileName = fileName;
        }
    }
}
