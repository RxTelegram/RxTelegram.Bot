namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
///     This object contains basic information about an invoice.
/// </summary>
public class Invoice
{
    /// <summary>
    ///     Product name
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Product description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Unique bot deep-linking parameter that can be used to generate this invoice
    /// </summary>
    public string StartParameter { get; set; }

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
}