namespace RxTelegram.Bot.Interface.BaseTypes;

public class KeyboardButton
{
    /// <summary>
    /// Text of the button. If none of the optional fields are used, it will be sent as a message when the button is pressed
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. If specified, pressing the button will open a list of suitable users.
    /// Identifiers of selected users will be sent to the bot in a “users_shared” service message. Available in private chats only.
    /// </summary>
    public KeyboardButtonRequestUsers RequestUsers { get; set; }

    /// <summary>
    /// Optional. If specified, pressing the button will open a list of suitable chats.
    /// Tapping on a chat will send its identifier to the bot in a “chat_shared” service message. Available in private chats only.
    /// </summary>
    public KeyboardButtonRequestChat RequestChat { get; set; }

    /// <summary>
    /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
    /// </summary>
    public bool? RequestContact { get; set; }

    /// <summary>
    /// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
    /// </summary>
    public bool? RequestLocation { get; set; }

    /// <summary>
    /// Optional. If specified, the user will be asked to create a poll and send it
    /// to the bot when the button is pressed. Available in private chats only
    /// </summary>
    public KeyboardButtonPollType RequestPoll { get; set; }

    /// <summary>
    /// Optional. If specified, the described Web App will be launched when the button is pressed.
    /// The Web App will be able to send a “web_app_data” service message. Available in private chats only.
    /// </summary>
    public WebAppInfo WebApp { get; set; }
}
