using RxTelegram.Bot.Interface.ChatBackground.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.ChatBackground;

public abstract class BackgroundFill  : IMultiTypeClassByType<BackgroundFillTypes>
{
    public abstract BackgroundFillTypes Type { get; set; }
}
