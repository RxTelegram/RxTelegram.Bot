using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Reaction.Enums;

public enum ReactionType
{
    [ImplementationType(typeof(ReactionTypeEmoji))]
    Emoji,

    [ImplementationType(typeof(ReactionTypeCustomEmoji))]
    CustomEmoji
}
