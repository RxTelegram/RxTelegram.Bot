using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Callbacks
{
    /// <summary>
    /// Use this method to send answers to callback queries sent from inline keyboards. The answer will be displayed to the user as a
    /// notification at the top of the chat screen or as an alert. On success, True is returned.
    /// </summary>
    public class AnswerCallbackQuery : BaseValidation
    {
        /// <summary>
        /// Required
        /// Unique identifier for the query to be answered
        /// </summary>
        public string CallbackQueryId { get; set; }

        /// <summary>
        /// Optional
        /// Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// If true, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to false.
        /// </summary>
        public bool ShowAlert { get; set; }

        /// <summary>
        /// URL that will be opened by the user's client. If you have created a Game and accepted the conditions via @Botfather, specify
        /// the URL that opens your game – note that this will only work if the query comes from a callback_game button.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional
        /// The maximum amount of time in seconds that the result of the callback query may be cached client-side. Telegram apps will
        /// support caching starting in version 3.14. Defaults to 0.
        /// </summary>
        public int CacheTime { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
