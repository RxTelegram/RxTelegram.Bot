﻿namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
///     This object represents a file ready to be downloaded. The file can be downloaded via
///     <see cref="ITelegramBot" />.GetFileAsync. It is guaranteed that the link will be valid for at least 1 hour.
///     When the link expires, a new one can be requested by calling <see cref="ITelegramBot" />.GetFileAsync.
/// </summary>
public class File : FileBase
{
    /// <summary>
    ///     File path. Use <see cref="ITelegramBot" />.GetFileAsync to get the file.
    /// </summary>
    public string FilePath { get; set; }
}
