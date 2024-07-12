using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums;

public enum PaidMediaType
{
    [ImplementationType(typeof(PaidMediaPreview))]
    Preview,

    [ImplementationType(typeof(PaidMediaPhoto))]
    Photo,

    [ImplementationType(typeof(PaidMediaVideo))]
    Video
}
