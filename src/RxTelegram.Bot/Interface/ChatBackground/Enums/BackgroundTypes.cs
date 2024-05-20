using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.ChatBackground.Enums;

public enum BackgroundTypes
{
    [ImplementationType(typeof(BackgroundTypeChatTheme))]
    ChatTheme,

    [ImplementationType(typeof(BackgroundTypeFill))]
    Fill,

    [ImplementationType(typeof(BackgroundTypePattern))]
    Pattern,

    [ImplementationType(typeof(BackgroundTypeWallpaper))]
    Wallpaper
}
