using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes;

public abstract class MessageOrigin : IMultiTypeClassByType<Enums.MessageOriginType>
{
    public abstract Enums.MessageOriginType Type { get; set; }
}
