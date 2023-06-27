using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to get the current default administrator rights of the bot. Returns ChatAdministratorRights on success.
/// </summary>
public class GetMyDefaultAdministratorRights : BaseValidation
{
    /// <summary>
    /// Pass True to get default administrator rights of the bot in channels.
    /// Otherwise, default administrator rights of the bot for groups and supergroups will be returned.
    /// </summary>
    public bool ForChannels { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}