﻿namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Collection of fileIds of profile pictures of a chat.
/// </summary>
public class ChatPhoto
{
    /// <summary>
    /// File id of the big version of this <see cref="ChatPhoto"/>
    /// </summary>
    public string BigFileId { get; set; }

    /// <summary>
    /// Unique file identifier of big (640x640) chat photo, which is supposed to be the same over time
    /// and for different bots. Can't be used to download or reuse the file.
    /// </summary>
    public string BigFileUniqueId { get; set; }

    /// <summary>
    /// File id of the small version of this <see cref="ChatPhoto"/>
    /// </summary>
    public string SmallFileId { get; set; }

    /// <summary>
    /// Unique file identifier of small (160x160) chat photo, which is supposed to be the same over
    /// time and for different bots. Can't be used to download or reuse the file.
    /// </summary>
    public string SmallFileUniqueId { get; set; }
}