namespace RxTelegram.Bot.Interface.InlineMode;

/// <summary>
/// Describes an inline message to be sent by a user of a Mini App.
/// </summary>
public class PreparedInlineMessage
{
    /// <summary>
    /// Unique identifier of the prepared message
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Expiration date of the prepared message, in Unix time. Expired prepared messages can no longer be used
    /// </summary>
    public int ExpirationDate { get; set; }
}
