using RxTelegram.Bot.Interface.BotCommandScope.Enums;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chats.
/// </summary>
public class BotCommandScopeAllGroupChats : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be all_group_chats
    /// </summary>
    public override BotCommandScopeTypes Type { get; set; } = BotCommandScopeTypes.AllGroupChats;
}
