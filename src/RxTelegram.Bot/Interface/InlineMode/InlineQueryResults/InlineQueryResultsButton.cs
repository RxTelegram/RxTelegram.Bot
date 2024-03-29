using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// This object represents a button to be shown above inline query results. You must use exactly one of the optional fields.
/// </summary>
public class InlineQueryResultsButton
{
    /// <summary>
    /// Label text on the button
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. Description of the Web App that will be launched when the user presses the button.
    /// The Web App will be able to switch back to the inline mode using the method switchInlineQuery inside the Web App.
    /// </summary>
    public WebAppInfo WebApp { get; set; }

    /// <summary>
    /// Optional. Deep-linking parameter for the /start message sent to the bot when a user presses the button.
    /// 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.
    /// </summary>
    public string StartParameter { get; set; }
}
