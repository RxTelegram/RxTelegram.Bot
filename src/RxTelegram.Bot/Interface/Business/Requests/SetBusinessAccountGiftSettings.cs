using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Changes the privacy settings pertaining to incoming gifts in a managed business account.
/// Requires the can_change_gift_settings business bot right.
/// </summary>
public class SetBusinessAccountGiftSettings : BaseBusinessRequest
{
    /// <summary>
    /// Pass True, if a button for sending a gift to the user or by the business account must always be shown in the input field
    /// </summary>
    public bool ShowGiftButton { get; set; }

    /// <summary>
    /// Types of gifts accepted by the business account
    /// </summary>
    public AccpetedGiftTypes AccpetedGiftTypes { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
