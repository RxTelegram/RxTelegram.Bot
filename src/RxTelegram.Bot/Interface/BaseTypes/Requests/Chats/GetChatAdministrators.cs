using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to get a list of administrators in a chat. On success, returns an Array of ChatMember objects that contains
    /// information about all chat administrators except other bots. If the chat is a group or a supergroup and no administrators were
    /// appointed, only the creator will be returned.
    /// </summary>
    public class GetChatAdministrators : BaseRequest
    {
        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
