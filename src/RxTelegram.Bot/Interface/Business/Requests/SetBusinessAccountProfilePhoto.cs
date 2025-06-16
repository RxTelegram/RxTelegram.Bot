using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Changes the profile photo of a managed business account. Requires the can_edit_profile_photo business bot right.
/// </summary>
public class SetBusinessAccountProfilePhoto : BaseBusinessRequest
{
    /// <summary>
    /// The new profile photo to set
    /// </summary>
    public InputProfilePhoto Photo { get; set; }

    /// <summary>
    /// Pass True to set the public photo, which will be visible even if the main photo is hidden by the business account's privacy settings.
    /// An account can have only one public photo.
    /// </summary>
    public bool? IsPublic { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
