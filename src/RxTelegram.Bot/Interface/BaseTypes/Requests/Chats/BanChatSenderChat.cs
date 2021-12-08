using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to ban a channel chat in a supergroup or a channel.
    /// Until the chat is unbanned, the owner of the banned chat won't be able to send messages on behalf of any of their channels.
    /// The bot must be an administrator in the supergroup or channel for this to work and must have the appropriate administrator rights.
    /// Returns True on success.
    /// </summary>
    public class BanChatSenderChat : BaseRequest
    {
        /// <summary>
        /// Unique identifier of the target sender chat
        /// </summary>
        public int SenderChatId { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
