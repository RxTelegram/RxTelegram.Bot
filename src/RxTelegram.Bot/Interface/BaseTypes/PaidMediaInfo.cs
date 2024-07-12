using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Describes the paid media added to a message.
/// </summary>
public class PaidMediaInfo
{
    /// <summary>
    /// The number of Telegram Stars that must be paid to buy access to the media
    /// </summary>
    public int StarCount { get; set; }

    /// <summary>
    /// Information about the paid media
    /// </summary>
    public List<PaidMedia> PaidMedia { get; set; }
}
