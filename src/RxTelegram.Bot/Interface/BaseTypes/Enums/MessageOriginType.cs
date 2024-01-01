using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums;

public enum MessageOriginType
{
    [ImplementationType(typeof(MessageOriginUser))]
    User,

    [ImplementationType(typeof(MessageOriginHiddenUser))]
    HiddenUser,

    [ImplementationType(typeof(MessageOriginChat))]
    Chat,

    [ImplementationType(typeof(MessageOriginChannel))]
    Channel
}
