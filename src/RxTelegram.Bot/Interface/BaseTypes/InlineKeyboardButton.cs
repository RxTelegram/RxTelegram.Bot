using RxTelegram.Bot.Interface.Games;

namespace RxTelegram.Bot.Interface.BaseTypes;

public class InlineKeyboardButton
{
    /// <summary>
    /// Label text on the button
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. HTTP or tg:// url to be opened when button is pressed
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Optional. An HTTP URL used to automatically authorize the user. Can be used as a replacement for the Telegram Login Widget.
    /// </summary>
    public LoginUrl LoginUrl { get; set; }

    /// <summary>
    /// Optional. If set, pressing the button will prompt the user to select one of their chats of the specified type,
    /// open that chat and insert the bot's username and the specified inline query in the input field
    /// </summary>
    public SwitchInlineQueryChosenChat SwitchInlineQueryChosenChat { get; set; }

    /// <summary>
    /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
    /// </summary>
    public string CallbackData { get; set; }

    /// <summary>
    /// Optional. Description of the Web App that will be launched when the user presses the button.
    /// The Web App will be able to send an arbitrary message on behalf of the user using the method answerWebAppQuery.
    /// Available only in private chats between a user and the bot.
    /// </summary>
    public WebAppInfo WebApp { get; set; }

    /// <summary>
    /// Optional. If set, pressing the button will prompt the user to select one of their chats,
    /// open that chat and insert the bot‘s username and the specified inline query in the input field.
    /// Can be empty, in which case just the bot’s username will be inserted.
    /// <remarks>
    /// Note: This offers an easy way for users to start using your bot in inline mode when they are currently in
    /// a private chat with it. Especially useful when combined with switch_pm… actions – in this case the user will
    /// be automatically returned to the chat they switched from, skipping the chat selection screen.
    /// </remarks>
    /// </summary>
    public string SwitchInlineQuery { get; set; }

    /// <summary>
    /// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query
    /// in the current chat's input field. Can be empty, in which case only the bot’s username will be inserted.
    /// This offers a quick way for the user to open your bot in inline mode in the same chat –
    /// good for selecting something from multiple options.
    /// </summary>
    public string SwitchInlineQueryCurrentChat { get; set; }

    /// <summary>
    /// Optional. Description of the game that will be launched when the user presses the button.
    /// NOTE: This type of button must always be the first button in the first row.
    /// </summary>
    public CallbackGame CallbackGame { get; set; }

    /// <summary>
    /// Optional. Specify True, to send a Pay button.
    /// NOTE: This type of button must always be the first button in the first row.
    /// </summary>
    public bool Pay { get; set; }
}
