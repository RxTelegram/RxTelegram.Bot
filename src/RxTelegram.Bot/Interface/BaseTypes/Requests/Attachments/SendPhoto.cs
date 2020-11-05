using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendPhoto : BaseSend
    {
        /// <summary>
        /// Photo to send
        /// </summary>
        public InputFile Photo { get; set; }

        /// <summary>
        /// Photo caption (may also be used when resending photos by file_id), 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// List of special entities that appear in the caption, which can be specified instead of parse_mode
        /// </summary>
        public IEnumerable<MessageEntity> CaptionEntities { get; set; }

        /// <summary>
        /// Pass True, if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
