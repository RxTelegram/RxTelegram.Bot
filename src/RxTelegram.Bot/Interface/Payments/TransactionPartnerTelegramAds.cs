using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a withdrawal transaction to the Telegram Ads platform.
/// </summary>
public class TransactionPartnerTelegramAds : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “telegram_ads”
    /// </summary>
    public override TransactionPartnerType Type { get; set; }
}
