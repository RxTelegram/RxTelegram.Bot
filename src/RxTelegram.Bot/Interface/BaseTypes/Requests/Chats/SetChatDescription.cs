using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to change the description of a group, a supergroup or a channel. The bot must be an administrator in the chat for
    /// this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class SetChatDescription : BaseRequest
    {
        /// <summary>
        /// Required
        /// New chat description, 0-255 characters
        /// </summary>
        public string Description { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
