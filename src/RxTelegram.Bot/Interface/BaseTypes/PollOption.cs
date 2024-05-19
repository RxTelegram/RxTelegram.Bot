using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about one answer option in a poll.
/// </summary>
public class PollOption
{
    /// <summary>
    /// Option text, 1-100 characters
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. Special entities that appear in the option text. Currently, only custom emoji entities are allowed in poll option texts
    /// </summary>
    public List<MessageEntity> TextEntities { get; set; }

    /// <summary>
    /// Number of users that voted for this option
    /// </summary>
    public int VoterCount { get; set; }
}
