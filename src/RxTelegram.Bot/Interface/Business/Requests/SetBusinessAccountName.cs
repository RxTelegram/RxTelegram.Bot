using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Changes the first and last name of a managed business account. Requires the can_change_name business bot right.
/// </summary>
public class SetBusinessAccountName : BaseBusinessRequest
{
    /// <summary>
    /// The new value of the first name for the business account; 1-64 characters
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The new value of the last name for the business account; 0-64 characters
    /// </summary>
    public string LastName { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
