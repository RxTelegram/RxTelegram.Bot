using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.Games.Requests
{
    /// <summary>
    /// Use this method to send a game. On success, the sent Message is returned.
    /// </summary>
    public class SendGame : BaseRequest
    {
        /// <summary>
        /// Short name of the game, serves as the unique identifier for the game. Set up your games via Botfather.
        /// </summary>
        public string GameShortName { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int ReplyToMessageId { get; set; }

        /// <summary>
        /// A JSON-serialized object for an inline keyboard. If empty, one ‘Play game_title’ button will be shown.
        /// If not empty, the first button must launch the game.
        /// </summary>
        public InlineKeyboardMarkup Type { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
