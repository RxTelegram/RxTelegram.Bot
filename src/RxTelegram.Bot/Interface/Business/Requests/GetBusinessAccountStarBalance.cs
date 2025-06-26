using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Returns the amount of Telegram Stars owned by a managed business account. Requires the can_view_gifts_and_stars business bot right.
/// Returns <see cref="StarAmount"/> on success.
/// </summary>
public class GetBusinessAccountStarBalance : BaseBusinessRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}
