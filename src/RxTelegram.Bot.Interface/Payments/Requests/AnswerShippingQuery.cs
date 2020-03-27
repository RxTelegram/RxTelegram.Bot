using System.Collections.Generic;
using RxTelegram.Bot.Interface.Payments.Requests.Base;

namespace RxTelegram.Bot.Interface.Payments.Requests
{
    /// <summary>
    /// If you sent an invoice requesting a shipping address and the parameter is_flexible was specified, the Bot API will send an Update
    /// with a shipping_query field to the bot. Use this method to reply to shipping queries. On success, True is returned.
    /// </summary>
    public class AnswerShippingQuery : BasePayment
    {
        /// <summary>
        /// Required
        /// Unique identifier for the query to be answered
        /// </summary>
        public string ShippingQueryId { get; set; }

        /// <summary>
        /// Optional
        /// Required if ok is True. A JSON-serialized array of available shipping options.
        /// </summary>
        public IEnumerable<ShippingOption> ShippingOptions { get; set; }
    }
}
