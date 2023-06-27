using System;
using System.Net;
using System.Runtime.Serialization;

namespace RxTelegram.Bot.Exceptions;

[Serializable]
public class GeneralApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public GeneralApiException(HttpStatusCode statusCode) : base("Telegram API error") => StatusCode = statusCode;

    protected GeneralApiException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
        base(serializationInfo, streamingContext)
    {
    }
}
