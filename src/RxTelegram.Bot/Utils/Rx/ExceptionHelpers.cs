using System;
using System.Threading;

namespace RxTelegram.Bot.Utils.Rx;

internal static class ExceptionHelpers
{
    internal static void ThrowIfFatal(Exception ex)
    {
        if (ex is OutOfMemoryException || ex is StackOverflowException
          || ex is ThreadAbortException)
        {
            throw ex;
        }
    }
}
