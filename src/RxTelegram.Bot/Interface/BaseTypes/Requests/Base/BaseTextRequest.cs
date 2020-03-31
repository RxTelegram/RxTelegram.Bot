using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Base
{
    public abstract class BaseTextRequest : BaseRequest
    {
        public ParseMode ParseMode { get; set; }
    }
}
