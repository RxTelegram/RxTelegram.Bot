using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to change the default administrator rights requested by the bot when it's added as an
/// administrator to groups or channels. These rights will be suggested to users, but they are are free to
/// modify the list before adding the bot.
/// Returns True on success.
/// </summary>
public class SetMyDefaultAdministratorRights : BaseValidation
{
    /// <summary>
    /// A JSON-serialized object describing new default administrator rights.
    /// If not specified, the default administrator rights will be cleared.
    /// </summary>
    public ChatAdministratorRights Rights { get; set; }

    /// <summary>
    /// Pass True to change the default administrator rights of the bot in channels.
    /// Otherwise, the default administrator rights of the bot for groups and supergroups will be changed.
    /// </summary>
    public bool ForChannels { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}