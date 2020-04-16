using System.IO;
using System.Threading.Tasks;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot.Api
{
    public static class TelegramApiExtensions
    {
        public static Task<Stream> DownloadFileStream(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileStream(file.FilePath);

        public static Task<string> DownloadFileString(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileString(file.FilePath);

        public static Task<byte[]> DownloadFileByteArray(this TelegramBot telegramBot, File file) =>
            telegramBot.DownloadFileByteArray(file.FilePath);

        public static async Task<(File file, Stream content)> GetFileAndDownloadStream(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileStream(file.FilePath);
            return (file, content);
        }

        public static async Task<(File file, string content)> GetFileAndDownloadString(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileString(file.FilePath);
            return (file, content);
        }

        public static async Task<(File file, byte[] content)> GetFileAndDownloadByteArray(this TelegramBot telegramBot, string fileId)
        {
            var file = await telegramBot.GetFile(fileId);
            var content = await telegramBot.DownloadFileByteArray(file.FilePath);
            return (file, content);
        }
    }
}
