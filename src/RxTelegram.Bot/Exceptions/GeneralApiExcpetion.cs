using System;
using System.Net;

namespace RxTelegram.Bot.Exceptions
{
    public class GeneralApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public GeneralApiException(HttpStatusCode statusCode) : base("Telegram API error") => StatusCode = statusCode;
    }
}
