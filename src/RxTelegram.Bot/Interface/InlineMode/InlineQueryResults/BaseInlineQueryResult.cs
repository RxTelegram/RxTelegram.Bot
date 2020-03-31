using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResult : BaseValidation
    {
        public string Id { get; set; }

        public abstract string Type { get; }

        /// <summary>
        /// Optional.
        /// Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
