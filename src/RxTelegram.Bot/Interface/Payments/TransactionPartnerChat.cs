using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Stickers;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a transaction with a chat.
/// </summary>
public class TransactionPartnerChat : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “chat”
    /// </summary>
    public override TransactionPartnerType Type { get; set; } = TransactionPartnerType.Chat;

    /// <summary>
    /// Information about the chat
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Optional. The gift sent to the chat by the bot
    /// </summary>
    public Gift Gift { get; set; }
}
