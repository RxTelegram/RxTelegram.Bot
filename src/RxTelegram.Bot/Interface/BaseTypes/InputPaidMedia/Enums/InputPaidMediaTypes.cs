using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia.Enums;

public enum InputPaidMediaTypes
{
    [ImplementationType(typeof(BaseInputPaidMediaPhoto))]
    Photo,


    [ImplementationType(typeof(BaseInputPaidMediaVideo))]
    Video
}
