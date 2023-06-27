namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object describes the bot's menu button in a private chat.
/// If a menu button other than MenuButtonDefault is set for a private chat, then it is applied in the chat.
/// Otherwise the default menu button is applied. By default, the menu button opens the list of bot commands.
/// </summary>
public class MenuButton
{
    /// <summary>
    /// Type of the button. Can be web_app, commands, default
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Text on the button
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Description of the Web App that will be launched when the user presses the button.
    /// The Web App will be able to send an arbitrary message on behalf of the user using the method answerWebAppQuery.
    /// </summary>
    public WebAppInfo WebApp { get; set; }
}
