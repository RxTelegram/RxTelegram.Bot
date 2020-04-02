using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to change the title of a chat. Titles can't be changed for private chats. The bot must be an administrator in the
    /// chat for this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class SetChatTitle : BaseRequest
    {
        /// <summary>
        /// Required
        /// New chat title, 1-255 characters
        /// </summary>
        public string Title { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
