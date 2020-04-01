using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to get the number of members in a chat. Returns Int on success.
    /// </summary>
    public class GetChatMembersCount : BaseRequest
    {
        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
