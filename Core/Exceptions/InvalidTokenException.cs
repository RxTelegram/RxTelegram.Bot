using System;

namespace Core.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string token) :
            base($"The given bot token is not valid. See \"https://core.telegram.org/bots/api#authorizing-your-bot\" " +
                 $"for further information. Token was: {token}")
        {
        }
    }
}
