using TelegramInterface.BaseTypes;

namespace TelegramInterface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResult
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
