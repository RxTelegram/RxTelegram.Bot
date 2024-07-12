using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object describes paid media.
/// </summary>
public abstract class PaidMedia :  IMultiTypeClassByType<PaidMediaType>
{
    public abstract PaidMediaType Type { get; set; }
}
