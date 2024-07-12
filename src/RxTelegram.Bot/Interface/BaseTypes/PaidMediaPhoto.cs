using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The paid media is a photo.
/// </summary>
public class PaidMediaPhoto : PaidMedia
{
    /// <summary>
    /// Type of the paid media, always “photo”
    /// </summary>
    public override PaidMediaType Type { get; set; } = PaidMediaType.Photo;

    /// <summary>
    /// The photo
    /// </summary>
    public List<PhotoSize> Photo { get; set; }
}
