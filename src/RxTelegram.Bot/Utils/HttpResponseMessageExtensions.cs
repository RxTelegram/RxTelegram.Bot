using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RxTelegram.Bot.Exceptions;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils;

internal static class HttpResponseMessageExtensions
{
    internal static async Task<T> ParseResponse<T>(this Task<HttpResponseMessage> responseMessage) =>
        await ParseResponse<T>(await responseMessage);

    private static async Task<T> ParseResponse<T>(this HttpResponseMessage responseMessage)
    {
        switch (responseMessage.StatusCode)
        {
            // official errors code of https://core.telegram.org/api/errors
            // try to parse response
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:
                break;
            default:
                responseMessage.EnsureSuccessStatusCode();
                break;
        }

        var apiResponse = await responseMessage.Content.ReadAsStreamAsync()
                                               .Deserialize<ApiResponse<T>>();

        switch (apiResponse?.Ok)
        {
            case true:
                return apiResponse.Result;
            case null:
                throw new GeneralApiException(responseMessage.StatusCode);
            default:
            {
                var errorCode = Enum.GetValues(typeof(ErrorCode))
                                    .Cast<ErrorCode?>()
                                    .FirstOrDefault(code => code.GetAttribute<RegexAttribute>()
                                                                ?.Match(apiResponse.Description) ==
                                                            true);
                throw new ApiException(responseMessage.StatusCode, apiResponse.Description, apiResponse.Parameters, errorCode);
            }
        }
    }
}