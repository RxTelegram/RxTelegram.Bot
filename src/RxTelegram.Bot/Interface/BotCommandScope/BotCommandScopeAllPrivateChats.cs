namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering all private chats.
/// </summary>
public class BotCommandScopeAllPrivateChats : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be all_private_chats
    /// </summary>
    public override string Type => "all_private_chats";
}
