using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

public class StoryAreaTypeUniqueGift
{
    /// <summary>
    /// Type of the area, always "unique_gift"
    /// </summary>
    public StoryAreaType Type => StoryAreaType.UniqueGift;

    /// <summary>
    /// Unique name of the gift
    /// </summary>
    public string Name { get; set; }
}
