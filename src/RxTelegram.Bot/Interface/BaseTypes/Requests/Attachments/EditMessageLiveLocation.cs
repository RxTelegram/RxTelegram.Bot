using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to edit live location messages. A location can be edited until its live_period expires or editing is explicitly
    /// disabled by a call to stopMessageLiveLocation. On success, if the edited message was sent by the bot, the edited Message is
    /// returned, otherwise True is returned.
    /// </summary>
    public class EditMessageLiveLocation : BaseRequest
    {
        /// <summary>
        /// Required if inline_message_id is not specified. Identifier of the message to edit
        /// </summary>
        public int? MessageId { get; set; }

        /// <summary>
        /// Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public string InlineMessageId { get; set; }

        /// <summary>
        /// Required
        /// Latitude of new location
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Required
        /// Longitude of new location
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for a new inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
