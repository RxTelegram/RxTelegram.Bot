﻿namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a voice note.
/// </summary>
public class Voice : FileBase
{
    /// <summary>
    /// Duration of the audio in seconds as defined by sender
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Optional. MIME type of the file as defined by sender
    /// </summary>
    public string MimeType { get; set; }
}
