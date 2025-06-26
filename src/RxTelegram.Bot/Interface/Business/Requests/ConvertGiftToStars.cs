using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Converts a given regular gift to Telegram Stars. Requires the can_convert_gifts_to_stars business bot right. Returns True on success.
/// </summary>
public class ConvertGiftToStars : BaseBusinessRequest
{
    /// <summary>
    /// Unique identifier of the regular gift that should be converted to Telegram Stars
    /// </summary>
    public string OwnedGiftId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
