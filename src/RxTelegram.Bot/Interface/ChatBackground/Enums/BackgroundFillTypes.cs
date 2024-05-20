using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.ChatBackground.Enums;

public enum BackgroundFillTypes
{
    [ImplementationType(typeof(BackgroundFillFreeformGradient))]
    FreeformGradient,

    [ImplementationType(typeof(BackgroundFillGradient))]
    Gradient,

    [ImplementationType(typeof(BackgroundFillSolid))]
    Solid
}
