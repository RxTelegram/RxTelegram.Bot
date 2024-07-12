using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums;

public enum RevenueWithdrawalStateType
{
    [ImplementationType(typeof(RevenueWithdrawalStatePending))]
    Pending,

    [ImplementationType(typeof(RevenueWithdrawalStateSucceeded))]
    Succeeded,

    [ImplementationType(typeof(RevenueWithdrawalStateFailed))]
    Failed
}
