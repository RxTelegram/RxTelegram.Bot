using RxTelegram.Bot.Interface.ChatBackground.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.ChatBackground;

public abstract class BackgroundType : IMultiTypeClassByType<BackgroundTypes>
{
    public abstract BackgroundTypes Type { get; set; }
}
