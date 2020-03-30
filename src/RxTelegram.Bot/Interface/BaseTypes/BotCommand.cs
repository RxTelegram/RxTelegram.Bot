namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a bot command.
    /// </summary>
    public class BotCommand
    {
        /// <summary>
        /// Text of the command, 1-32 characters. Can contain only lowercase English letters, digits and underscores.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Description of the command, 3-256 characters.
        /// </summary>
        public string Description { get; set; }
    }
}
