using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public class StopPoll : BaseValidation
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

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
