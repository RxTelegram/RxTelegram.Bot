using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to set a new profile photo for the chat. Photos can't be changed for private chats. The bot must be an administrator
    /// in the chat for this to work and must have the appropriate admin rights. Returns True on success.
    /// </summary>
    public class SetChatPhoto : BaseRequest
    {
        /// <summary>
        /// Required
        /// New chat photo, uploaded using multipart/form-data
        /// </summary>
        public InputFile Photo { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
