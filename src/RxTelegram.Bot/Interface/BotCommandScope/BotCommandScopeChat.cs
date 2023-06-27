using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the scope of bot commands, covering a specific chat.
/// </summary>
public class BotCommandScopeChat : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be chat
    /// </summary>
    public override string Type => "chat";

    /// <summary>
    /// Unique identifier for the target chat or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    public ChatId ChatId { get; set; }
}