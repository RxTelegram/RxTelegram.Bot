using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RxTelegram.Bot.Api
{
    internal static class StreamExtensions
    {
        private static T Deserialize<T>(this Stream stream)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(stream);
                var reader = new JsonTextReader(sr);
                var serializer = JsonSerializer.Create(BaseTelegramBot.JsonSerializerSettings);

                return serializer.Deserialize<T>(reader);
            }
            finally
            {
                sr?.Dispose();
            }
        }

        public static async Task<T> Deserialize<T>(this Task<Stream> stream) => Deserialize<T>(await stream);
    }
}
