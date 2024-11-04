using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a transaction with payment for paid broadcasting.
/// </summary>
public class TransactionPartnerTelegramApi : TransactionPartner
{
    public override TransactionPartnerType Type { get; set; } = TransactionPartnerType.TelegramApi;

    public int RequestCount { get; set; }
}
