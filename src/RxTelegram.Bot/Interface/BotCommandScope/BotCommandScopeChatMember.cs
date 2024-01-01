using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BotCommandScope.Enums;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering a specific member of a group or supergroup chat.
/// </summary>
public class BotCommandScopeChatMember : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be chat_member
    /// </summary>
    public override BotCommandScopeTypes Type { get; set; } = BotCommandScopeTypes.ChatMember;

    /// <summary>
    /// Unique identifier for the target chat or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    public ChatId ChatId { get; set; }

    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public int UserId { get; set; }
}
