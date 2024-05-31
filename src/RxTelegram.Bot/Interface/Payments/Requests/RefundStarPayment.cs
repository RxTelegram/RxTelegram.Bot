using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Payments.Requests;

public class RefundStarPayment : BaseValidation
{
    /// <summary>
    /// Identifier of the user whose payment will be refunded
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Telegram payment identifier
    /// </summary>
    public string TelegramPaymentChargeId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
