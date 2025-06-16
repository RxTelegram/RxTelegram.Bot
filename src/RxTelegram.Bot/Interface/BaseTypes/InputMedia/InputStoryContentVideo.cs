using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

/// <summary>
/// Describes a video to post as a story.
/// </summary>
public class InputStoryContentVideo : InputStoryContent
{
    public InputStoryContentTypes Type { get; set; } = InputStoryContentTypes.Video;

    /// <summary>
    /// The video to post as a story. The video must be of the size 720x1280, streamable, encoded with H.265 codec,
    /// with key frames added each second in the MPEG4 format, and must not exceed 30 MB.
    /// The video can't be reused and can only be uploaded as a new file, so you can pass “attach://<file_attach_name>”
    /// if the video was uploaded using multipart/form-data under <file_attach_name>.
    /// </summary>
    public string Video { get; set; }

    /// <summary>
    /// Optional. Precise duration of the video in seconds; 0-60
    /// </summary>
    public double Duration { get; set; }

    /// <summary>
    /// Optional. Timestamp in seconds of the frame that will be used as the static cover for the story. Defaults to 0.0.
    /// </summary>
    public double CoverFrameTimestamp { get; set; } = 0.0;

    /// <summary>
    /// Optional. Pass True if the video has no sound
    /// </summary>
    public bool NoSound { get; set; } = false;
}
