namespace RxTelegram.Bot.Interface.Reaction;

public class ReactionTypeCustomEmoji : ReactionType
{
    public override Enums.ReactionType Type { get; set; } = Enums.ReactionType.CustomEmoji;

    public string CustomEmoji { get; set; }
}
