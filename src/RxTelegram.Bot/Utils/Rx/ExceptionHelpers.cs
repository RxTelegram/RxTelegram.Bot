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

    internal static void ThrowIfDisposed(this IDisposable disposable, Func<bool> isDisposed)
    {
        if (isDisposed())
        {
            throw new ObjectDisposedException(disposable.GetType().FullName);
        }

    }
}
