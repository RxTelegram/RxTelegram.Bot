using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Changes the username of a managed business account. Requires the can_change_username business bot right.
/// </summary>
public class SetBusinessAccountUsername: BaseBusinessRequest
{
    /// <summary>
    /// The new value of the username for the business account; 0-32 characters
    /// </summary>
    public string Username { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
