using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Changes the bio of a managed business account. Requires the can_change_bio business bot right.
/// </summary>
public class SetBusinessAccountBio : BaseBusinessRequest
{
    /// <summary>
    /// The new value of the bio for the business account; 0-140 characters
    /// </summary>
    public string Bio { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
