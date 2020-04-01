using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Payments.Requests
{
    /// <summary>
    /// Use this method to send invoices. On success, the sent Message is returned.
    /// </summary>
    public class SendInvoice : BaseValidation
    {
        /// <summary>
        /// Required
        /// Unique identifier for the target private chat
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// Required
        /// Product name, 1-32 characters
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Required
        /// Product description, 1-255 characters
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required
        /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Required
        /// Payments provider token, obtained via Botfather
        /// </summary>
        public string ProviderToken { get; set; }

        /// <summary>
        /// Required
        /// Unique deep-linking parameter that can be used to generate this invoice when used as a start parameter
        /// </summary>
        public string StartParameter { get; set; }

        /// <summary>
        /// Required
        /// Three-letter ISO 4217 currency code, see more on currencies
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Required
        /// Price breakdown, a JSON-serialized list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)
        /// </summary>
        public IEnumerable<LabeledPrice> Prices { get; set; }

        /// <summary>
        /// Optional
        /// JSON-encoded data about the invoice, which will be shared with the payment provider. A detailed description of required fields
        /// should be provided by the payment provider.
        /// </summary>
        public string ProviderData { get; set; }

        /// <summary>
        /// Optional
        /// URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. People like it better
        /// when they see what they are paying for.
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Optional
        /// Photo size
        /// </summary>
        public int? PhotoSize { get; set; }

        /// <summary>
        /// Optional
        /// Photo width
        /// </summary>
        public int? PhotoWidth { get; set; }

        /// <summary>
        /// Optional
        /// Photo height
        /// </summary>
        public int? PhotoHeight { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's full name to complete the order
        /// </summary>
        public bool? NeedName { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's phone number to complete the order
        /// </summary>
        public bool? NeedPhoneNumber { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's email address to complete the order
        /// </summary>
        public bool? NeedEmail { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's shipping address to complete the order
        /// </summary>
        public bool? NeedShippingAddress { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's email address to complete the order
        /// </summary>
        public bool? SendPhoneNumberToProvider { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if you require the user's shipping address to complete the order
        /// </summary>
        public bool? SendEmailToProvider { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the final price depends on the shipping method
        /// </summary>
        public bool? IsFlexible { get; set; }

        /// <summary>
        /// Optional
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for an inline keyboard. If empty, one 'Pay total price' button will be shown.
        /// If not empty, the first button must be a Pay button.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
