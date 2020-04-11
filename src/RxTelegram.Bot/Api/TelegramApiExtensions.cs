using System.IO;
using System.Threading.Tasks;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot.Api
{
    public static class TelegramApiExtensions
    {
        public static Task<Stream> DownloadFileStream(this TelegramApi telegramApi, File file) =>
            telegramApi.DownloadFileStream(file.FilePath);

        public static Task<string> DownloadFileString(this TelegramApi telegramApi, File file) =>
            telegramApi.DownloadFileString(file.FilePath);

        public static Task<byte[]> DownloadFileByteArray(this TelegramApi telegramApi, File file) =>
            telegramApi.DownloadFileByteArray(file.FilePath);

        public static async Task<(File file, Stream content)> GetFileAndDownloadStream(this TelegramApi telegramApi, string fileId)
        {
            var file = await telegramApi.GetFile(fileId);
            var content = await telegramApi.DownloadFileStream(file.FilePath);
            return (file, content);
        }

        public static async Task<(File file, string content)> GetFileAndDownloadString(this TelegramApi telegramApi, string fileId)
        {
            var file = await telegramApi.GetFile(fileId);
            var content = await telegramApi.DownloadFileString(file.FilePath);
            return (file, content);
        }

        public static async Task<(File file, byte[] content)> GetFileAndDownloadByteArray(this TelegramApi telegramApi, string fileId)
        {
            var file = await telegramApi.GetFile(fileId);
            var content = await telegramApi.DownloadFileByteArray(file.FilePath);
            return (file, content);
        }
    }
}
