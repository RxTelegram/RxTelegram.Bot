using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResultMedia : BaseInlineQueryResult
    {
        public string Title { get; set; }

        /// <summary>
        /// Content of the message to be sent
        /// </summary>
        public InputMessageContent InputMessageContent { get; set; }

        public string Id { get; set; }

        /// <summary>
        /// Optional.
        /// Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
