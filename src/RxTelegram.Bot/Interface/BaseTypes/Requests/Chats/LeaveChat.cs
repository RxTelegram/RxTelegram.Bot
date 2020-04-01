using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method for your bot to leave a group, supergroup or channel. Returns True on success.
    /// </summary>
    public class LeaveChat : BaseRequest
    {
        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
