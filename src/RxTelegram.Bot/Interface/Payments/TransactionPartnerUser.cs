using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a transaction with a user.
/// </summary>
public class TransactionPartnerUser : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “user”
    /// </summary>
    public override TransactionPartnerType Type { get; set; } = TransactionPartnerType.User;

    /// <summary>
    /// Information about the user
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Optional. Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }
}
