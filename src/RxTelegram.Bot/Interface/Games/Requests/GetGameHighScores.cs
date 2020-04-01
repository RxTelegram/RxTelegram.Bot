using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Games.Requests
{
    public class GetGameHighScores : BaseRequest
    {
        /// <summary>
        /// Target user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Required if inline_message_id is not specified. Identifier of the sent message
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public string InlineMessageId { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
