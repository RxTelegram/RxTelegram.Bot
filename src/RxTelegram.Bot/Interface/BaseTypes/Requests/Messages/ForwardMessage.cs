using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Use this method to forward messages of any kind. On success, the sent Message is returned.
    /// </summary>
    public class ForwardMessage : BaseRequest, IProtectContent
    {
        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public int MessageThreadId { get; set; }

        /// <summary>
        /// Required
        /// Unique identifier for the target chat or username of the
        /// target channel (in the format @channelusername)
        /// </summary>
        public ChatId FromChatId { get; set; }

        /// <summary>
        /// Optional
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Required
        /// Message identifier in the chat specified in from_chat_id
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
