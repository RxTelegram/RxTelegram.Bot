using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Removes the current profile photo of a managed business account. Requires the can_edit_profile_photo business bot right.
/// </summary>
public class RemoveBusinessAccountProfilePhoto : BaseBusinessRequest
{
    /// <summary>
    /// Pass True to remove the public photo, which will be visible even if the main photo is hidden by the business account's privacy settings.
    /// </summary>
    public bool? IsPublic { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
