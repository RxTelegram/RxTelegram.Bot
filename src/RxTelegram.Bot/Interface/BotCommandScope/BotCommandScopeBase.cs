using RxTelegram.Bot.Interface.BotCommandScope.Enums;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BotCommandScope;

public abstract class BotCommandScopeBase : IMultiTypeClassByType<BotCommandScopeTypes>
{
    /// <summary>
    /// Scope type
    /// </summary>
    public abstract BotCommandScopeTypes Type { get; set; }
}
