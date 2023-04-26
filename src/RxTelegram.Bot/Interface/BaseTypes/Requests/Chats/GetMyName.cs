namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to get the current bot name for the given user language. Returns BotName on success.
/// </summary>
public class GetMyName
{
    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    public string LanguageCode { get; set; }
}
