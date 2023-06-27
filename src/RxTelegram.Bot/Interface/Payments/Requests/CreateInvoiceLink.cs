using System.Collections.Generic;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Payments.Requests;

/// <summary>
/// Use this method to create a link for an invoice.
/// </summary>
public class CreateInvoiceLink : BaseValidation
{
    /// <summary>
    /// Product name, 1-32 characters
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Product description, 1-255 characters
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.
    /// </summary>
    public string Payload { get; set; }

    /// <summary>
    /// Payment provider token, obtained via BotFather
    /// </summary>
    public string ProviderToken { get; set; }

    /// <summary>
    /// Three-letter ISO 4217 currency code, see https://core.telegram.org/bots/payments#supported-currencies
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Price breakdown, a JSON-serialized list of components
    /// (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)
    /// </summary>
    public List<LabeledPrice> Prices { get; set; }

    /// <summary>
    /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
    /// <example>
    /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145.
    /// See the exp parameter in currencies.json, it shows the number of digits past the decimal point for
    /// each currency (2 for the majority of currencies). Defaults to 0
    /// </example>
    /// </summary>
    public int? MaxTipAmount { get; set; }

    /// <summary>
    /// A JSON-serialized array of suggested amounts of tips in the smallest units of the currency (integer, not float/double).
    /// At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive, passed in a strictly increased
    /// order and must not exceed max_tip_amount.
    /// </summary>
    public List<int> SuggestedTipAmounts { get; set; }

    /// <summary>
    /// JSON-serialized data about the invoice, which will be shared with the payment provider.
    /// A detailed description of required fields should be provided by the payment provider.
    /// </summary>
    public string ProviderData { get; set; }

    /// <summary>
    /// URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service.
    /// </summary>
    public string PhotoUrl { get; set; }

    /// <summary>
    /// Photo size in bytes
    /// </summary>
    public int? PhotoSize { get; set; }

    /// <summary>
    /// Photo width
    /// </summary>
    public int? PhotoWidth { get; set; }

    /// <summary>
    /// Photo height
    /// </summary>
    public int? PhotoHeight { get; set; }

    /// <summary>
    /// Pass True, if you require the user's full name to complete the order
    /// </summary>
    public bool? NeedName { get; set; }

    /// <summary>
    /// Pass True, if you require the user's phone number to complete the order
    /// </summary>
    public bool? NeedPhoneNumber { get; set; }

    /// <summary>
    /// Pass True, if you require the user's email address to complete the order
    /// </summary>
    public bool? NeedEmail { get; set; }

    /// <summary>
    /// Pass True, if you require the user's shipping address to complete the order
    /// </summary>
    public bool? NeedShippingAddress { get; set; }

    /// <summary>
    /// Pass True, if the user's phone number should be sent to the provider
    /// </summary>
    public bool? SendPhoneNumberToProvider { get; set; }

    /// <summary>
    /// Pass True, if the user's email address should be sent to the provider
    /// </summary>
    public bool? SendEmailToProvider { get; set; }

    /// <summary>
    /// Pass True, if the final price depends on the shipping method
    /// </summary>
    public bool? IsFlexible { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
