using System.Collections.Generic;
using TelegramInterface.BaseTypes.Requests.Base;
using TelegramInterface.BaseTypes.Requests.Base.Interfaces;

namespace TelegramInterface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to send a native poll. On success, the sent Message is returned.
    /// </summary>
    public class SendPoll : BaseRequest
    {
        /// <summary>
        /// Required
        /// Poll question, 1-255 characters
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Required
        /// A JSON-serialized list of answer options, 2-10 strings 1-100 characters each
        /// </summary>
        public IEnumerable<string>  Options { get; set; }

        /// <summary>
        /// Optional
        /// True, if the poll needs to be anonymous, defaults to True
        /// </summary>
        public bool? IsAnonymous { get; set; }

        /// <summary>
        /// Type
        /// Poll type, “quiz” or “regular”, defaults to “regular”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Optional
        /// True, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to False
        /// </summary>
        public bool? AllowsMultipleAnswers { get; set; }

        /// <summary>
        /// Optional
        /// 0-based identifier of the correct answer option, required for polls in quiz mode
        /// </summary>
        public int? CorrectOptionId { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the poll needs to be immediately closed. This can be useful for poll preview.
        /// </summary>
        public bool? IsClosed { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup ReplyMarkup { get; set; }
    }
}
