﻿namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
///     This object represents a file ready to be downloaded. The file can be downloaded
///     via <see cref="ITelegramBot.DownloadFileStream(string)" />. It is guaranteed that the link will be valid for
///     at least 1 hour. When the link expires, a new one can be requested by calling <see cref="ITelegramBot.GetFile" />.
/// </summary>
public abstract class FileBase
{
    /// <summary>
    ///     Identifier for this file, which can be used to download or reuse the file
    /// </summary>
    public string FileId { get; set; }

    /// <summary>
    ///     Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse
    ///     the file.
    /// </summary>
    public string FileUniqueId { get; set; }

    /// <summary>
    ///     Optional. File size, if known
    /// </summary>
    public long? FileSize { get; set; }
}
