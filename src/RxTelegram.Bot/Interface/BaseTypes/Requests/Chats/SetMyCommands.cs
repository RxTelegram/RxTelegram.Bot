using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to change the list of the bot's commands. Returns True on success.
    /// </summary>
    public class SetMyCommands
    {
        /// <summary>
        /// A JSON-serialized list of bot commands to be set as the list of the bot's commands. At most 100 commands can be specified.
        /// </summary>
        public IEnumerable<BotCommand> Commands { get; set; }
    }
}
