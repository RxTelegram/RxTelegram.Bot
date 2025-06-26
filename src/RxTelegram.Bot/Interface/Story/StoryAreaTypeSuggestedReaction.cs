using RxTelegram.Bot.Interface.Reaction.Enums;
using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes a story area pointing to a suggested reaction. Currently, a story can have up to 5 suggested reaction areas.
/// </summary>
public class StoryAreaTypeSuggestedReaction
{
    /// <summary>
    /// Type of the area, always "suggested_reaction"
    /// </summary>
    public StoryAreaType Type => StoryAreaType.SuggestedReaction;

    /// <summary>
    /// Type of the reaction
    /// </summary>
    public ReactionType ReactionType { get; set; }

    /// <summary>
    /// Optional. Pass True if the reaction area has a dark background
    /// </summary>
    public bool? IsDark { get; set; }

    /// <summary>
    /// Optional. Pass True if reaction area corner is flipped
    /// </summary>
    public bool? IsFlipped { get; set; }
}
