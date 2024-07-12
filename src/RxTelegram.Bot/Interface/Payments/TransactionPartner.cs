using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Payments;

public abstract class TransactionPartner: IMultiTypeClassByType<TransactionPartnerType>
{
    public abstract TransactionPartnerType Type { get; set; }
}
