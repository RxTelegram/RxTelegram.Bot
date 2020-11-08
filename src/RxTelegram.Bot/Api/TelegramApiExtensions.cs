using System.IO;
using System.Threading;
using System.Threading.Tasks;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot.Api
{
    public static class TelegramApiExtensions
    {
        /// <summary>
        ///    Provides a stream to download a file.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="file">The file to Download. File object is returned by <see cref="TelegramBot.GetFile(string,CancellationToken)"/></param>
        /// <returns>Stream for the file to download.</returns>
        public static Task<Stream> DownloadFileStream(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileStream(file.FilePath);

        /// <summary>
        ///    Provides a string representation of a file.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="file">The file to Download. File object is returned by <see cref="TelegramBot.GetFile(string,CancellationToken)"/></param>
        /// <returns>String representation of the downloaded File.</returns>
        public static Task<string> DownloadFileString(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileString(file.FilePath);

        /// <summary>
        /// Provides a byte array of a file.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="file">The file to Download. File object is returned by <see cref="TelegramBot.GetFile(string,CancellationToken)"/></param>
        /// <returns>Byte array of the file to download.</returns>
        public static Task<byte[]> DownloadFileByteArray(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileByteArray(file.FilePath);

        /// <summary>
        /// Provides detailed information for a File and the content of the File based on the fileId.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="fileId">Identifier of the file.</param>
        /// <returns>Tupel of a file and a stream that represents the file.</returns>
        public static async Task<(File file, Stream content)> GetFileAndDownloadStream(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileStream(file.FilePath);
            return (file, content);
        }

        /// <summary>
        /// Provides detailed information for a File and the content of the File based on the fileId.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="fileId">Identifier of the file.</param>
        /// <returns>Tupel of a file and a string that represents the file.</returns>
        public static async Task<(File file, string content)> GetFileAndDownloadString(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileString(file.FilePath);
            return (file, content);
        }

        /// <summary>
        /// Provides detailed information for a File and the content of the File based on the fileId.
        /// </summary>
        /// <param name="telegramBot">Extended object</param>
        /// <param name="fileId">Identifier of the file.</param>
        /// <returns>Tupel of a file and the byte array that represents the file.</returns>
        public static async Task<(File file, byte[] content)> GetFileAndDownloadByteArray(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileByteArray(file.FilePath);
            return (file, content);
        }
    }
}
