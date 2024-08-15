namespace RxTelegram.Bot.Interface.Reaction;

public class ReactionTypePaid : ReactionType
{
    public override Enums.ReactionType Type { get; set; } = Enums.ReactionType.Paid;
}
