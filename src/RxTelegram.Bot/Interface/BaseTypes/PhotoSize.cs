﻿namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents one size of a photo or a file / sticker thumbnail.
/// </summary>
/// <remarks>A missing thumbnail for a file (or sticker) is presented as an empty object.</remarks>
public class PhotoSize : FileBase
{
    /// <summary>
    /// Photo width
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Photo height
    /// </summary>
    public int Height { get; set; }
}