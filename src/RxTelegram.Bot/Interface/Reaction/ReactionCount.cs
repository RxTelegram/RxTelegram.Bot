namespace RxTelegram.Bot.Interface.Reaction;

/// <summary>
/// Represents a reaction added to a message along with the number of times it was added.
/// </summary>
public class ReactionCount
{
    /// <summary>
    /// Type of the reaction
    /// </summary>
    public ReactionType Type { get; set; }

    /// <summary>
    /// Number of times the reaction was added
    /// </summary>
    public long TotalCount { get; set; }
}
