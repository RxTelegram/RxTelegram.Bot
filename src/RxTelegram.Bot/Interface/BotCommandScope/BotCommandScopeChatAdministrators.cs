using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.BotCommandScope
{
    /// <summary>
    /// Represents the scope of bot commands, covering all administrators of a specific group or supergroup chat.
    /// </summary>
    public class BotCommandScopeChatAdministrators : BotCommandScopeBase
    {
        /// <summary>
        /// Scope type, must be chat_administrators
        /// </summary>
        public override string Type => "chat_administrators";

        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup
        /// (in the format @supergroupusername)
        /// </summary>
        public ChatId ChatId { get; set; }
    }
}
