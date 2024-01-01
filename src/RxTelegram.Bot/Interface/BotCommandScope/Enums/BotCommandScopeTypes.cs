using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BotCommandScope.Enums;

public enum BotCommandScopeTypes
{
    [ImplementationType(typeof(BotCommandScopeDefault))]
    Default,

    [ImplementationType(typeof(BotCommandScopeAllPrivateChats))]
    AllPrivateChats,

    [ImplementationType(typeof(BotCommandScopeAllGroupChats))]
    AllGroupChats,

    [ImplementationType(typeof(BotCommandScopeAllChatAdministrators))]
    AllChatAdministrators,

    [ImplementationType(typeof(BotCommandScopeChat))]
    Chat,

    [ImplementationType(typeof(BotCommandScopeChatAdministrators))]
    ChatAdministrators,

    [ImplementationType(typeof(BotCommandScopeChatMember))]
    ChatMember
}
