using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResult : BaseValidation
    {
        public abstract string Type { get; }
    }
}
