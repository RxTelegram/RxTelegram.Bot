using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    public class SendMessage : BaseTextRequest, IProtectContent
    {
        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public int MessageThreadId { get; set; }

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
        public IReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// List of special entities that appear in message text, which can be specified instead of parse_mode
        /// </summary>
        public IEnumerable<MessageEntity> Entities { get; set; }

        /// <summary>
        /// Pass True, if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
