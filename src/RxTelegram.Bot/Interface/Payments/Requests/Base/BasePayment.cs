using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.Payments.Requests.Base;

public abstract class BasePayment : BaseValidation
{
    /// <summary>
    /// Optional
    /// Required if ok is False. Error message in human readable form that explains why it is impossible to complete the order
    /// (e.g. "Sorry, delivery to your desired address is unavailable'). Telegram will display this message to the user.
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Required
    /// Specify True if delivery to the specified address is possible and False if there are any problems (for example, if delivery to
    /// the specified address is not possible)
    /// </summary>
    public bool Ok { get; set; }
}