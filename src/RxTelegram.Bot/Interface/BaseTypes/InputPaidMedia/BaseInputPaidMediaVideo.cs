using RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia;

/// <summary>
/// The paid media to send is a video.
/// </summary>
public class BaseInputPaidMediaVideo : BaseInputPaidMedia
{
    /// <summary>
    /// Type of the media, must be video
    /// </summary>
    public override InputPaidMediaTypes Type { get; set; } = InputPaidMediaTypes.Video;

    /// <summary>
    /// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended), pass an HTTP URL for Telegram to
    /// get a file from the Internet, or pass “attach://{file_attach_name}” to upload a new one using multipart/form-data
    /// under {file_attach_name} name.
    /// </summary>
    public string Media { get; set; }

    /// <summary>
    ///     Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should
    ///     be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the file is
    ///     not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you can
    ///     pass “attach://{file_attach_name}” if the thumbnail was uploaded using multipart/form-data under {file_attach_name}.
    /// </summary>
    public InputFile Thumbnail { get; set; }

    /// <summary>
    /// Cover for the video in the message.
    /// Pass a file_id to send a file that exists on the Telegram servers (recommended),
    /// pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://file_attach_name”
    /// to upload a new one using multipart/form-data under file_attach_name name.
    /// </summary>
    public string Cover { get; set; }

    /// <summary>
    /// Optional. Start timestamp for the video in the message
    /// </summary>
    public long StartTimestamp { get; set; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Optional. Video duration in seconds
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Optional. Pass True if the uploaded video is suitable for streaming
    /// </summary>
    public bool SupportsStreaming { get; set; }
}
