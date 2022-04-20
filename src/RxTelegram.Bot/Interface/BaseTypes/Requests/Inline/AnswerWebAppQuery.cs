using RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Inline
{
    /// <summary>
    /// Use this method to set the result of an interaction with a Web App and send a corresponding
    /// message on behalf of the user to the chat from which the query originated.
    /// On success, a SentWebAppMessage object is returned.
    /// </summary>
    public class AnswerWebAppQuery
    {
        /// <summary>
        /// Required
        /// Unique identifier for the query to be answered
        /// </summary>
        public string WebAppQueryId { get; set; }

        /// <summary>
        /// Required
        /// A JSON-serialized object describing the message to be sent
        /// </summary>
        public BaseInlineQueryResult Type { get; set; }
    }
}
