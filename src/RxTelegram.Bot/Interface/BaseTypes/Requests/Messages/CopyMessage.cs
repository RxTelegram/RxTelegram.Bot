using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Use this method to copy messages of any kind. The method is analogous to the method forwardMessages,
    /// but the copied message doesn't have a link to the original message. Returns the MessageId of the sent message on success.
    /// </summary>
    public class CopyMessage : BaseSend
    {
        public string FromChatId { get; set; }

        public int MessageId { get; set; }

        public string Caption { get; set; }

        public IEnumerable<MessageEntity> CaptionEntities { get; set; }

        public bool? AllowSendingWithoutReply { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
