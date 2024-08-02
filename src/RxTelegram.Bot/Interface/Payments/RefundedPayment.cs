namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// This object contains basic information about a refunded payment.
/// </summary>
public class RefundedPayment
{
    /// <summary>
    /// Three-letter ISO 4217 currency code, or “XTR” for payments in Telegram Stars. Currently, always “XTR”
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Total refunded price in the smallest units of the currency (integer, not float/double).
    /// For example, for a price of US$ 1.45, total_amount = 145.
    /// See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency
    /// (2 for the majority of currencies).
    /// </summary>
    public int TotalAmount { get; set; }

    /// <summary>
    /// Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    /// Telegram payment identifier
    /// </summary>
    public string TelegramPaymentChargeId { get; set; }

    /// <summary>
    /// Optional. Provider payment identifier
    /// </summary>
    public string ProviderPaymentChargeId { get; set; }
}
