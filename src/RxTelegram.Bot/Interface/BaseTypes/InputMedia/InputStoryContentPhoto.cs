using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

/// <summary>
/// Describes a photo to post as a story.
/// </summary>
public class InputStoryContentPhoto : InputStoryContent
{
    public InputStoryContentTypes Type { get; set; } = InputStoryContentTypes.Photo;

    /// <summary>
    /// The photo to post as a story. The photo must be of the size 1080x1920 and must not exceed 10 MB.
    /// The photo can't be reused and can only be uploaded as a new file,
    /// so you can pass “attach://<file_attach_name>” if the photo was uploaded using multipart/form-data under <file_attach_name>.
    /// </summary>
    public string Photo { get; set; }
}
