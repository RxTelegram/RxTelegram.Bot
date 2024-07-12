using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Contains a list of Telegram Star transactions.
/// </summary>
public class StarTransactions
{
    /// <summary>
    /// The list of transactions
    /// </summary>
    public List<StarTransaction> Transactions { get; set; }
}
