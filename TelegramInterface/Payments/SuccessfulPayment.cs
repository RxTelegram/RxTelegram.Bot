namespace TelegramInterface.Payments
{
    /// <summary>
    /// This object contains basic information about a successful payment.
    /// <see cref="https://core.telegram.org/bots/api#successfulpayment"/>
    /// </summary>
    public class SuccessfulPayment
    {
        /// <summary>
        /// Three-letter ISO 4217 currency code
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Price of the product in the smallest units of the currency (integer, not float/double).
        /// For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in
        /// <see cref="https://core.telegram.org/bots/payments/currencies.json"/> currencies.json,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        public string InvoicePayload { get; set; }

        /// <summary>
        /// Optional. Identifier of the shipping option chosen by the user
        /// </summary>
        public string ShippingOptionId { get; set; }

        /// <summary>
        /// Optional. Order info provided by the user
        /// </summary>
        public OrderInfo OrderInfo { get; set; }

        /// <summary>
        /// Telegram payment identifier
        /// </summary>
        public string TelegramPaymentChargeId { get; set; }

        /// <summary>
        /// Provider payment identifier
        /// </summary>
        public string ProviderPaymentChargeId { get; set; }
    }
}
