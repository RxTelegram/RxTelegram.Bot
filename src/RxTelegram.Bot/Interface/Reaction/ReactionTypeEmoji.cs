namespace RxTelegram.Bot.Interface.Reaction;

public class ReactionTypeEmoji : ReactionType
{
    public override Enums.ReactionType Type { get; set; } = Enums.ReactionType.Emoji;

    public string Emoji { get; set; }
}
