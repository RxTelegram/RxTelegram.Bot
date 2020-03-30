namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    public abstract class BaseInlineQueryResultMedia : BaseInlineQueryResult
    {
        public string Title { get; set; }

        /// <summary>
        /// Content of the message to be sent
        /// </summary>
        public InputMessageContent InputMessageContent { get; set; }
    }
}
