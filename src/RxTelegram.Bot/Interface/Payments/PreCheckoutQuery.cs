using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
///     This object contains information about an incoming pre-checkout query. https://core.telegram.org/bots/api#precheckoutquery
/// </summary>
public class PreCheckoutQuery
{
    /// <summary>
    ///     Unique query identifier
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     User who sent the query
    /// </summary>
    public User From { get; set; }

    /// <summary>
    ///     Three-letter ISO 4217 https://core.telegram.org/bots/payments#supported-currencies currency code
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    ///     Price of the product in the smallest units of the currency (integer, not float/double).
    ///     For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in
    ///     https://core.telegram.org/bots/payments/currencies.json currencies.json,
    ///     it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    /// </summary>
    public int TotalAmount { get; set; }

    /// <summary>
    ///     Bot specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    ///     Optional. Identifier of the shipping option chosen by the user
    /// </summary>
    public string ShippingOptionId { get; set; }

    /// <summary>
    ///     Optional. Order info provided by the user
    /// </summary>
    public OrderInfo OrderInfo { get; set; }
}