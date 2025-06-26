using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes a clickable area on a story media.
/// </summary>
public class StoryArea
{
    /// <summary>
    /// Position of the area
    /// </summary>
    public StoryAreaPosition Position { get; set; }

    /// <summary>
    /// Type of the area
    /// </summary>
    public StoryAreaType Type { get; set; }
}
