namespace TelegramInterface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public class StopPoll
    {
        /// <summary>
        /// Required
        /// Identifier of the original message with the poll
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for a new message inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
