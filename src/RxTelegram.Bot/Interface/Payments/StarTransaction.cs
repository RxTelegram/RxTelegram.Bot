namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
/// Describes a Telegram Star transaction.
/// </summary>
public class StarTransaction
{
    /// <summary>
    /// Unique identifier of the transaction. Coincides with the identifer of the original transaction for refund transactions.
    /// Coincides with SuccessfulPayment.telegram_payment_charge_id for successful incoming payments from users.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Number of Telegram Stars transferred by the transaction
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Date the transaction was created in Unix time
    /// </summary>
    public int Date { get; set; }

    /// <summary>
    /// Optional. Source of an incoming transaction (e.g., a user purchasing goods or services, Fragment refunding a failed withdrawal).
    /// Only for incoming transactions
    /// </summary>
    public TransactionPartner Source { get; set; }

    /// <summary>
    /// Optional. Receiver of an outgoing transaction (e.g., a user for a purchase refund, Fragment for a withdrawal).
    /// Only for outgoing transactions
    /// </summary>
    public TransactionPartner Receiver { get; set; }
}
