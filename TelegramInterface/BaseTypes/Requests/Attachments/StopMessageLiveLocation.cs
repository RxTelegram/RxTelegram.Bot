using TelegramInterface.BaseTypes.Requests.Base;

namespace TelegramInterface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to stop updating a live location message before live_period expires. On success, if the message was sent by the bot,
    /// the sent Message is returned, otherwise True is returned.
    /// </summary>
    public class StopMessageLiveLocation : BaseRequest
    {
        /// <summary>
        /// Required if inline_message_id is not specified. Identifier of the message with live location to stop
        /// </summary>
        public int? MessageId { get; set; }

        /// <summary>
        /// Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public string InlineMessageId { get; set; }

        /// <summary>
        /// A JSON-serialized object for a new inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

    }
}
