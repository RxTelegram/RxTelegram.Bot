using RxTelegram.Bot.Interface.BotCommandScope;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to get the current list of the bot's commands for the given scope and user language.
/// Returns Array of BotCommand on success. If commands aren't set, an empty list is returned.
/// </summary>
public class GetMyCommands
{
    /// <summary>
    /// A JSON-serialized object, describing scope of users. Defaults to BotCommandScopeDefault.
    /// </summary>
    public BotCommandScopeBase Scope { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    public string LanguageCode { get; set; }
}