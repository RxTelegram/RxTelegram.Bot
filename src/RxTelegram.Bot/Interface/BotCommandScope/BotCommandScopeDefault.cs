using RxTelegram.Bot.Interface.BotCommandScope.Enums;

namespace RxTelegram.Bot.Interface.BotCommandScope;

/// <summary>
/// Represents the default scope of bot commands.
/// Default commands are used if no commands with a narrower scope are specified for the user.
/// </summary>
public class BotCommandScopeDefault : BotCommandScopeBase
{
    /// <summary>
    /// Scope type, must be default
    /// </summary>
    public override BotCommandScopeTypes Type { get; set; } = BotCommandScopeTypes.Default;
}
