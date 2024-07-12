using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// The withdrawal succeeded.
/// </summary>
public class RevenueWithdrawalStateSucceeded: RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “succeeded”
    /// </summary>
    public override RevenueWithdrawalStateType Type { get; set; } = RevenueWithdrawalStateType.Succeeded;

    /// <summary>
    /// Date the withdrawal was completed in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// An HTTPS URL that can be used to see transaction details
    /// </summary>
    public string Url { get; set; }

}
