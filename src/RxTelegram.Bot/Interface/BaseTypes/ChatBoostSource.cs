using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes;

public abstract class ChatBoostSource : IMultiTypeClassBySource<ChatBoostSourceType>
{
    public abstract ChatBoostSourceType Source { get; set; }
}
