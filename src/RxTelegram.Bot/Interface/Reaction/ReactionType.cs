using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Reaction;

public abstract class ReactionType : IMultiTypeClassByType<Enums.ReactionType>
{
    public abstract Enums.ReactionType Type { get; set; }
}
