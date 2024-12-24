using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Payments.Requests;

/// <summary>
/// Allows the bot to cancel or re-enable extension of a subscription paid in Telegram Stars. Returns True on success.
/// </summary>
public class EditUserStarSubscription : BaseValidation
{
    /// <summary>
    /// Identifier of the user whose subscription will be edited
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Telegram payment identifier for the subscription
    /// </summary>
    public string TelegramPaymentChargeId { get; set; }

    /// <summary>
    /// Pass True to cancel extension of the user subscription;
    /// the subscription must be active up to the end of the current subscription period.
    /// Pass False to allow the user to re-enable a subscription that was previously canceled by the bot.
    /// </summary>
    public bool IsCanceled { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
