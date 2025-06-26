using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

public interface InputStoryContent
{
    /// <summary>
    ///     Type of the result
    /// </summary>
    public abstract InputStoryContentTypes Type { get; set; }
}
