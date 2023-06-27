using System.Collections.Generic;
using RxTelegram.Bot.Interface.BotCommandScope;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to change the list of the bot's commands. Returns True on success.
/// </summary>
public class SetMyCommands : BaseValidation
{
    /// <summary>
    /// A JSON-serialized list of bot commands to be set as the list of the bot's commands. At most 100 commands can be specified.
    /// </summary>
    public IEnumerable<BotCommand> Commands { get; set; }

    /// <summary>
    /// A JSON-serialized object, describing scope of users for which the commands are relevant.
    /// Defaults to BotCommandScopeDefault.
    /// </summary>
    public BotCommandScopeBase Scope { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code.
    /// If empty, commands will be applied to all users from the given scope,
    /// for whose language there are no dedicated commands
    /// </summary>
    public string LanguageCode { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}