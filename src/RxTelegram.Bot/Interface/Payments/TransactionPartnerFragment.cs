using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a withdrawal transaction with Fragment.
/// </summary>
public class TransactionPartnerFragment : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “fragment”
    /// </summary>
    public override TransactionPartnerType Type { get; set; } = TransactionPartnerType.Fragment;

    /// <summary>
    /// Optional. State of the transaction if the transaction is outgoing
    /// </summary>
    public RevenueWithdrawalState WithdrawalState { get; set; }
}
