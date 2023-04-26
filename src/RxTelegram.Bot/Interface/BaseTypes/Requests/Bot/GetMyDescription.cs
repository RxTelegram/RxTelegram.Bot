using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Bot;

/// <summary>
/// Use this method to get the current bot description for the given user language. Returns BotDescription on success.
/// </summary>
public class GetMyDescription : BaseValidation
{
    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    public string LanguageCode { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
