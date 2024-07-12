using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a transaction with an unknown source or recipient.
/// </summary>
public class TransactionPartnerOther : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “other”
    /// </summary>
    public override TransactionPartnerType Type { get; set; }
}
