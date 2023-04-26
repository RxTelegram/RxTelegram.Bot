namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Bot;

/// <summary>
/// Use this method to get the current bot short description for the given user language.
/// Returns <see cref="BotShortDescription"/> on success.
/// </summary>
public class GetMyShortDescription
{
    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    public string LanguageCode { get; set; }
}
