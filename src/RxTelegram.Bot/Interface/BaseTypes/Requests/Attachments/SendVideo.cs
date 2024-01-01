using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
///     Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). On success, the
///     sent Message is returned. Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
/// </summary>
public class SendVideo : BaseSend, IProtectContent
{
    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    ///     Required
    ///     Video to send. Pass a file_id as String to send a video that exists on the Telegram servers (recommended), pass an HTTP URL as a
    ///     String for Telegram to get a video from the Internet, or upload a new video using multipart/form-data. More info on Sending Files »
    /// </summary>
    public InputFile Video { get; set; }

    /// <summary>
    ///     Optional
    ///     Duration of sent video in seconds
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    ///     Optional
    ///     Video width
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    ///     Optional
    ///     Video height
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    ///     Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should
    ///     be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the file is
    ///     not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you can
    ///     pass “attach://{file_attach_name}” if the thumbnail was uploaded using multipart/form-data under {file_attach_name}.
    /// </summary>
    public InputFile Thumbnail { get; set; }

    /// <summary>
    ///     Video caption (may also be used when resending videos by file_id), 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    ///     Pass True, if the uploaded video is suitable for streaming
    /// </summary>
    public bool SupportsStreaming { get; set; }

    /// <summary>
    /// List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Pass True if the photo needs to be covered with a spoiler animation
    /// </summary>
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
