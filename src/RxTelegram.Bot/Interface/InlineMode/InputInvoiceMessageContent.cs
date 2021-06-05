using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Payments;

namespace RxTelegram.Bot.Interface.InlineMode
{
    /// <summary>
    /// Represents the <see cref="InputMessageContent"/> of an invoice message
    /// to be sent as the result of an inline query.
    /// </summary>
    public class InputInvoiceMessageContent
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
        /// Bot-defined invoice payload, 1-128 bytes.
        /// This will not be displayed to the user, use for your internal processes.
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Payment provider token, obtained via Botfather
        /// </summary>
        public string ProviderToken { get; set; }

        /// <summary>
        /// Three-letter ISO 4217 currency code, see more on currencies
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ISO4217 Currency { get; set; }

        /// <summary>
        /// Price breakdown, a JSON-serialized list of components (e.g. product price,
        /// tax, discount, delivery cost, delivery tax, bonus, etc.)
        /// </summary>
        public List<LabeledPrice> Prices { get; set; }

        /// <summary>
        /// Optional.
        /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
        /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145. See the exp parameter in currencies.json,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        ///
        /// Defaults to 0
        /// </summary>
        public int MaxTipAmount	{ get; set; }

        /// <summary>
        /// Optional.
        /// A JSON-serialized array of suggested amounts of tip in the smallest units of the currency (integer, not float/double).
        /// At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive,
        /// passed in a strictly increased order and must not exceed max_tip_amount.
        /// </summary>
        public int[] SuggestedTipAmounts { get; set; }

        /// <summary>
        /// Optional.
        /// A JSON-serialized object for data about the invoice, which will be shared with the payment provider.
        /// A detailed description of the required fields should be provided by the payment provider.
        /// </summary>
        public string ProviderData { get; set; }

        /// <summary>
        /// Optional.
        /// URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service.
        /// People like it better when they see what they are paying for.
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Optional. Photo size
        /// </summary>
        public int PhotoSize { get; set; }

        /// <summary>
        /// Optional. Photo width
        /// </summary>
        public int PhotoWidth { get; set; }

        /// <summary>
        /// Optional. Photo height
        /// </summary>
        public int PhotoHeight { get; set; }

        /// <summary>
        /// Optional. Pass True, if you require the user's full name to complete the order
        /// </summary>
        public bool NeedName { get; set; }

        /// <summary>
        /// Optional. Pass True, if you require the user's phone number to complete the order
        /// </summary>
        public bool NeedPhoneNumber { get; set; }

        /// <summary>
        /// Optional. Pass True, if you require the user's shipping address to complete the order
        /// </summary>
        public bool NeedShippingAddress	 { get; set; }

        /// <summary>
        /// Optional. Pass True, if user's phone number should be sent to provider
        /// </summary>
        public bool SendPhoneNumberToProvider { get; set; }

        /// <summary>
        /// Optional. Pass True, if user's email address should be sent to provider
        /// </summary>
        public bool SendEmailToProvider { get; set; }

        /// <summary>
        /// Optional. Pass True, if the final price depends on the shipping method
        /// </summary>
        public bool IsFlexible { get; set; }
    }
}
