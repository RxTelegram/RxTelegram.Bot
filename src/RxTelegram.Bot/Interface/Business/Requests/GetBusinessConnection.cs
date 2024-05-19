namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Use this method to get information about the connection of the bot with a business account.
/// Returns a <see cref="BusinessConnection"/> object on success.
/// </summary>
public class GetBusinessConnection
{
    /// <summary>
    /// Unique identifier of the business connection
    /// </summary>
    public string BusinessConnectionId { get; set; }
}
