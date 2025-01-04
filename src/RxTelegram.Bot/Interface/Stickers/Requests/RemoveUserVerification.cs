using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Removes verification from a user who is currently verified on behalf of the organization represented by the bot.
/// Returns True on success.
/// </summary>
public class RemoveUserVerification : BaseValidation
{
    /// <summary>
    /// User identifier of the user to be removed
    /// </summary>
    public long UserId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
