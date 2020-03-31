using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method for your bot to leave a group, supergroup or channel. Returns True on success.
    /// </summary>
    public class LeaveChat : BaseRequest
    {
        protected override void Validate() => throw new System.NotImplementedException();
    }
}
