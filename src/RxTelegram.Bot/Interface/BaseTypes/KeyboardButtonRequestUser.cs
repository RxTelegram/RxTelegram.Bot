namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object defines the criteria used to request a suitable user.
/// The identifier of the selected user will be shared with the bot when the corresponding button is pressed.
/// </summary>
public class KeyboardButtonRequestUser
{
    /// <summary>
    /// Signed 32-bit identifier of the request
    /// </summary>
    public int RequestId { get; set; }

    /// <summary>
    /// Optional. Pass True to request a bot, pass False to request a regular user.
    /// If not specified, no additional restrictions are applied.
    /// </summary>
    public bool UserIsBot { get; set; }

    /// <summary>
    /// Optional. Pass True to request a premium user, pass False to request a non-premium user.
    /// If not specified, no additional restrictions are applied.
    /// </summary>
    public bool UserIsPremium { get; set; }
}
