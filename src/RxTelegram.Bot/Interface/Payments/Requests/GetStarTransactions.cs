namespace RxTelegram.Bot.Interface.Payments.Requests;

/// <summary>
/// Returns the bot's Telegram Star transactions in chronological order.
/// On success, returns a <see cref="StarTransactions"/> StarTransactions object.
/// </summary>
public class GetStarTransactions
{
    /// <summary>
    /// Number of transactions to skip in the response
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// The maximum number of transactions to be retrieved. Values between 1-100 are accepted. Defaults to 100.
    /// </summary>
    public int? Limit { get; set; }
}
