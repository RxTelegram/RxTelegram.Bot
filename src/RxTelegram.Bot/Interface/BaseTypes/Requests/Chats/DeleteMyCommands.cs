using RxTelegram.Bot.Interface.BotCommandScope;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to delete the list of the bot's commands for the given scope and user language.
/// After deletion, higher level commands will be shown to affected users. Returns True on success.
/// </summary>
public class DeleteMyCommands
{
    /// <summary>
    /// A JSON-serialized object, describing scope of users for which the commands are relevant. Defaults to BotCommandScopeDefault.
    /// </summary>
    public BotCommandScopeBase Scope { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code.
    /// If empty, commands will be applied to all users from the given scope, for whose language there are no dedicated commands
    /// </summary>
    public string LanguageCode { get; set; }
}
