using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes the affiliate program that issued the affiliate commission received via this transaction.
/// </summary>
public class TransactionPartnerAffiliateProgram : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “affiliate_program”
    /// </summary>
    public override TransactionPartnerType Type { get; set; } = TransactionPartnerType.AffiliateProgram;

    /// <summary>
    /// Optional. Information about the bot that sponsored the affiliate program
    /// </summary>
    public User SponsorUser { get; set; }

    /// <summary>
    /// The number of Telegram Stars received by the bot for each 1000 Telegram Stars received by the affiliate program sponsor from referred users
    /// </summary>
    public int CommissionPerMille { get; set; }
}
