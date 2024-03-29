namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Contains information about why a request was unsuccessful.
/// </summary>
public class ResponseParameters
{
    /// <summary>
    /// The group has been migrated to a supergroup with the specified identifier.
    /// </summary>
    public long MigrateToChatId { get; set; }

    /// <summary>
    /// In case of exceeding flood control, the number of seconds left to wait before the request can be repeated.
    /// </summary>
    public int RetryAfter { get; set; }
}