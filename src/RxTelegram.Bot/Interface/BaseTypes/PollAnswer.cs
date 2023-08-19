using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents an answer of a user in a non-anonymous poll.
/// </summary>
public class PollAnswer
{
    /// <summary>
    /// Unique poll identifier
    /// </summary>
    public string PollId { get; set; }

    /// <summary>
    /// Optional. The chat that changed the answer to the poll, if the voter is anonymous
    /// </summary>
    public Chat VoterChat { get; set; }

    /// <summary>
    /// The user, who changed the answer to the poll
    /// </summary>
    /// <remarks>
    /// For backward compatibility, the field user contain the user 136817688 (@Channel_Bot) when VoterChat is set
    /// </remarks>
    public User User { get; set; }

    /// <summary>
    /// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
    /// </summary>
    public IEnumerable<int> OptionIds { get; set; }
}
