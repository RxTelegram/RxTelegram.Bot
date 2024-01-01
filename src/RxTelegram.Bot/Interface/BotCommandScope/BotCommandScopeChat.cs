using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BotCommandScope.Enums;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering a specific chat.
/// </summary>
public class BotCommandScopeChat : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be chat
    /// </summary>
    public override BotCommandScopeTypes Type { get; set; } = BotCommandScopeTypes.Chat;

    /// <summary>
    /// Unique identifier for the target chat or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    public ChatId ChatId { get; set; }
}
