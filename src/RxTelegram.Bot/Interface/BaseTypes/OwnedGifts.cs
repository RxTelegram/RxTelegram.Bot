using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Contains the list of gifts received and owned by a user or a chat.
/// </summary>
public class OwnedGifts
{
    /// <summary>
    /// The total number of gifts owned by the user or the chat
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// The list of gifts
    /// </summary>
    public List<OwnedGift> Gifts { get; set; }

    /// <summary>
    /// Offset for the next request. If empty, then there are no more results
    /// </summary>
    public string? NextOffset { get; set; }
}
