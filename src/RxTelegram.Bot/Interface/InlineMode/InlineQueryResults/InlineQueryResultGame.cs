using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a Game.
    /// </summary>
    public class InlineQueryResultGame : BaseInlineQueryResult
    {
        public override string Type { get; } = "game";

        public string Id { get; set; }

        /// <summary>
        /// Optional.
        /// Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Short name of the game
        /// </summary>
        public string GameShortName { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
