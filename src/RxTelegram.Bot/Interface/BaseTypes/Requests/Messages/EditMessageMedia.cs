using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Use this method to edit animation, audio, document, photo, or video messages. If a message is a part of a message album, then it can
    /// be edited only to a photo or a video. Otherwise, message type can be changed arbitrarily. When inline message is edited, new file
    /// can't be uploaded. Use previously uploaded file via its file_id or specify a URL. On success, if the edited message was sent by the
    /// bot, the edited Message is returned, otherwise True is returned.
    /// </summary>
    public class EditMessageMedia : BaseRequest
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
        /// A JSON-serialized object for a new media content of the message
        /// </summary>
        public BaseInputMedia Media { get; set; }

        /// <summary>
        /// A JSON-serialized object for a new inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
