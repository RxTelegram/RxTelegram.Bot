using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The paid media is a video.
/// </summary>
public class PaidMediaVideo : PaidMedia
{
    /// <summary>
    /// Type of the paid media, always “video”
    /// </summary>
    public override PaidMediaType Type { get; set; } = PaidMediaType.Video;

    /// <summary>
    /// The video
    /// </summary>
    public Video Video { get; set; }
}
