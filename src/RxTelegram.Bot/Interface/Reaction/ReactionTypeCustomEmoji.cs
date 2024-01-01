namespace RxTelegram.Bot.Interface.Reaction;

/// <summary>
/// The reaction is based on a custom emoji.
/// </summary>
public class ReactionTypeCustomEmoji : ReactionType
{
    /// <summary>
    /// Type of the reaction, always “custom_emoji”
    /// </summary>
    public override Enums.ReactionType Type { get; set; } = Enums.ReactionType.CustomEmoji;

    /// <summary>
    /// Custom emoji identifier
    /// </summary>
    public string CustomEmoji { get; set; }
}
