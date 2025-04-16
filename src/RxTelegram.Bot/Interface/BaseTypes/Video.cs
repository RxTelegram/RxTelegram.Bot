using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a video file.
/// </summary>
public class Video : FileBase
{
    /// <summary>
    /// Video width as defined by sender
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Video height as defined by sender
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Duration of the video in seconds as defined by sender
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Video thumbnail
    /// </summary>
    public PhotoSize Thumbnail { get; set; }

    /// <summary>
    /// Optional. Available sizes of the cover of the video in the message
    /// </summary>
    public List<PhotoSize> Cover { get; set; }

    /// <summary>
    /// Optional. Timestamp in seconds from which the video will play in the message
    /// </summary>
    public long StartTimestamp { get; set; }

    /// <summary>
    /// Original filename as defined by sender
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Optional. Mime type of a file as defined by sender
    /// </summary>
    public string MimeType { get; set; }
}
