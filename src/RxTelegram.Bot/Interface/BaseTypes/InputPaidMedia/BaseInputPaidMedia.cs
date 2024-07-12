using RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia;

public abstract class BaseInputPaidMedia : IMultiTypeClassByType<InputPaidMediaTypes>
{
    public abstract InputPaidMediaTypes Type { get; set; }
}
