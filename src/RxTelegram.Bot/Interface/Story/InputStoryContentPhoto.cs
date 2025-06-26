using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes a photo to post as a story.
/// </summary>
public class InputStoryContentPhoto
{
    /// <summary>
    /// Type of the content, must be "photo"
    /// </summary>
    public InputStoryType Type => InputStoryType.Photo;

    /// <summary>
    /// The photo to post as a story. The photo must be of the size 1080x1920 and must not exceed 10 MB.
    /// The photo can't be reused and can only be uploaded as a new file, so you can pass “attach://&lt;file_attach_name&gt;”
    /// if the photo was uploaded using multipart/form-data under &lt;file_attach_name&gt;.
    /// </summary>
    public string Photo { get; set; }
}
