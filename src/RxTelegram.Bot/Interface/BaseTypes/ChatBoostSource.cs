using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

public abstract class ChatBoostSource
{
    public abstract ChatBoostSourceType Source { get; protected set; }
}
