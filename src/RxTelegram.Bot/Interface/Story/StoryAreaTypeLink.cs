using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes a story area pointing to an HTTP or tg:// link. Currently, a story can have up to 3 link areas.
/// </summary>
public class StoryAreaTypeLink
{
    /// <summary>
    /// Type of the area, always "link"
    /// </summary>
    public StoryAreaType Type => StoryAreaType.Link;

    /// <summary>
    /// HTTP or tg:// URL to be opened when the area is clicked
    /// </summary>
    public string Url { get; set; }
}
