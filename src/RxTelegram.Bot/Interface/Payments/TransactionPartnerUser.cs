using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Stickers;

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

    public AffiliateInfo Affiliate { get; set; }

    /// <summary>
    /// Optional. Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    /// Optional. The duration of the paid subscription
    /// </summary>
    public int? SubscriptionPeriod { get; set; }

    /// <summary>
    /// Optional. Information about the paid media bought by the user
    /// </summary>
    public List<PaidMedia> PaidMedia { get; set; }

    /// <summary>
    /// Optional. Bot-specified paid media payload
    /// </summary>
    public string PaidMediaPayload { get; set; }

    /// <summary>
    /// Optional. The gift sent to the user by the bot
    /// </summary>
    public Gift Gift { get; set; }

    /// <summary>
    /// Optional. Number of months the gifted Telegram Premium subscription will be active for; for “premium_purchase” transactions only
    /// </summary>
    public int PremiumSubscriptionDuration { get; set; }
}
