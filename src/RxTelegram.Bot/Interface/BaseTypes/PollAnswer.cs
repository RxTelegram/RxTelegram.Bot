using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

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
    /// The user, who changed the answer to the poll
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
    /// </summary>
    public IEnumerable<int> OptionIds { get; set; }
}
