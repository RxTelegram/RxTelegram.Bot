using System;
using System.Net.Http;
using System.Threading.Tasks;
using TelegramInterface.BaseTypes;

namespace Core.Api
{
    internal static class TelegramApiExtensions
    {
        public static async Task<T> ParseResponse<T>(this Task<HttpResponseMessage> responseMessage) =>
            await ParseResponse<T>(await responseMessage);

        private static async Task<T> ParseResponse<T>(this HttpResponseMessage responseMessage)
        {
            var apiResponse = await responseMessage.Content.ReadAsStreamAsync()
                                                   .Deserialize<ApiResponse<T>>();
            if (apiResponse.Ok != true)
            {
                throw new Exception("todo");
            }

            return apiResponse.Result;
        }
    }
}
