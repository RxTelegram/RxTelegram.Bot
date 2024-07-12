using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// The withdrawal failed and the transaction was refunded.
/// </summary>
public class RevenueWithdrawalStateFailed: RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “failed”
    /// </summary>
    public override RevenueWithdrawalStateType Type { get; set; } = RevenueWithdrawalStateType.Failed;
}
