using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Payments;


public abstract class RevenueWithdrawalState : IMultiTypeClassByType<RevenueWithdrawalStateType>
{
    public abstract RevenueWithdrawalStateType Type { get; set; }
}
