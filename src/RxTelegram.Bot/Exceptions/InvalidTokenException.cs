using System;
using System.Runtime.Serialization;

namespace RxTelegram.Bot.Exceptions;

[Serializable]
public class InvalidTokenException : Exception
{
    public InvalidTokenException(string token) :
        base($"The given bot token is not valid. See \"https://core.telegram.org/bots/api#authorizing-your-bot\" " +
             $"for further information. Token was: {token}")
    {
    }

    protected InvalidTokenException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
        base(serializationInfo, streamingContext)
    {
    }
}
