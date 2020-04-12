using System.Collections.Generic;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to change the list of the bot's commands. Returns True on success.
    /// </summary>
    public class SetMyCommands : BaseValidation
    {
        /// <summary>
        /// A JSON-serialized list of bot commands to be set as the list of the bot's commands. At most 100 commands can be specified.
        /// </summary>
        public IEnumerable<BotCommand> Commands { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
