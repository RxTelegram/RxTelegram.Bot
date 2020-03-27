using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Use this method to edit text and game messages. On success, if edited message is sent by the bot, the edited Message is returned,
    /// otherwise True is returned.
    /// </summary>
    public class EditMessageText : BaseTextRequest
    {
        /// <summary>
        /// Optional
        /// Required if inline_message_id is not specified. Identifier of the message to edit
        /// </summary>
        public int? MessageId { get; set; }

        /// <summary>
        /// Optional
        /// Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public string InlineMessageId { get; set; }

        /// <summary>
        /// Required
        /// New text of the message, 1-4096 characters after entities parsing
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional
        /// Disables link previews for links in this message
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for an inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
