using RxTelegram.Bot.Interface.BotCommandScope.Enums;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chat administrators.
/// </summary>
public class BotCommandScopeAllChatAdministrators : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be all_chat_administrators
    /// </summary>
    public override BotCommandScopeTypes Type { get; set; } = BotCommandScopeTypes.AllChatAdministrators;
}
