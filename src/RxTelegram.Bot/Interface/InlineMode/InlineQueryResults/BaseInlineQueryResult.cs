using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResult : BaseValidation
    {
        public abstract string Type { get; }
    }
}
