namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chats.
/// </summary>
public class BotCommandScopeAllGroupChats : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be all_group_chats
    /// </summary>
    public override string Type => "all_group_chats";
}
