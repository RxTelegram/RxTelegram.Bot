using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

public abstract class BaseBusinessRequest : BaseValidation
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public string BusinessConnectionId { get; set; }
}
