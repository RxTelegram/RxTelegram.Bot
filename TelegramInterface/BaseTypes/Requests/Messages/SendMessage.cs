using TelegramInterface.BaseTypes.Requests.Base;
using TelegramInterface.BaseTypes.Requests.Base.Interfaces;

namespace TelegramInterface.BaseTypes.Requests.Messages
{
    public class SendMessage : BaseTextRequest
    {
        /// <summary>
        /// Required
        /// Text of the message to be sent, 1-4096 characters after entities parsing
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional
        /// Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width
        /// text or inline URLs in your bot's message.
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }

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
        /// Additional interface options. A JSON-serialized object for an inline keyboard,
        /// custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup Type { get; set; }
    }
}
