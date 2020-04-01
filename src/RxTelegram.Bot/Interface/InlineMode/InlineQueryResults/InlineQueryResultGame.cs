using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a Game.
    /// </summary>
    public class InlineQueryResultGame : BaseInlineQueryResult
    {
        public override string Type { get; } = "game";

        /// <summary>
        /// Short name of the game
        /// </summary>
        public string GameShortName { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
