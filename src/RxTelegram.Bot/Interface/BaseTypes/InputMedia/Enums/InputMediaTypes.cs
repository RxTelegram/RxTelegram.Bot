using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

public enum InputMediaTypes
{
    [ImplementationType(typeof(InputMediaAnimation))]
    Animation,

    [ImplementationType(typeof(InputMediaAudio))]
    Audio,

    [ImplementationType(typeof(InputMediaDocument))]
    Document,

    [ImplementationType(typeof(InputMediaPhoto))]
    Photo,

    [ImplementationType(typeof(InputMediaVideo))]
    Video
}
