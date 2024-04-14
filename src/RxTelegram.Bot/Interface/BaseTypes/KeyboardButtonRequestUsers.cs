namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object defines the criteria used to request a suitable user.
/// The identifier of the selected user will be shared with the bot when the corresponding button is pressed.
/// </summary>
public class KeyboardButtonRequestUsers
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

    /// <summary>
    /// Optional. The maximum number of users to be selected; 1-10. Defaults to 1.
    /// </summary>
    public int MaxQuantity { get; set; }

    /// <summary>
    /// Optional. Pass True to request the users' first and last name
    /// </summary>
    public bool RequestName { get; set; }

    /// <summary>
    /// Optional. Pass True to request the users' username
    /// </summary>
    public bool RequestUsername { get; set; }

    /// <summary>
    /// Optional. Pass True to request the users' photo
    /// </summary>
    public bool RequestPhoto { get; set; }
}
