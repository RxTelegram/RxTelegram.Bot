namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chat administrators.
/// </summary>
public class BotCommandScopeAllChatAdministrators : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be all_chat_administrators
    /// </summary>
    public override string Type => "all_chat_administrators";
}