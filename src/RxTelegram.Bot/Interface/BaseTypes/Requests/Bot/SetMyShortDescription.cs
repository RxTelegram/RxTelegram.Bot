using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Bot;

/// <summary>
/// Use this method to change the bot's short description, which is shown on the bot's profile page and is sent together with the
/// link when users share the bot. Returns True on success.
/// </summary>
public class SetMyShortDescription : BaseValidation
{
    /// <summary>
    /// New short description for the bot; 0-120 characters.
    /// Pass an empty string to remove the dedicated short description for the given language.
    /// </summary>
    public string ShortDescription { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code.
    /// If empty, the short description will be applied to all users for whose language there is no dedicated short description.
    /// </summary>
    public string LanguageCode { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
