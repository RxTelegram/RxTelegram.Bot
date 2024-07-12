using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// The withdrawal is in progress.
/// </summary>
public class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “pending”
    /// </summary>
    public override RevenueWithdrawalStateType Type { get; set; } = RevenueWithdrawalStateType.Pending;
}
