using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to get information about a member of a chat. Returns a ChatMember object on success.
    /// </summary>
    public class GetChatMember : BaseRequest
    {
        public int UserId { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
