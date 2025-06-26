using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Transfers Telegram Stars from the business account balance to the bot's balance.
/// Requires the can_transfer_stars business bot right. Returns True on success.
/// </summary>
public class TransferBusinessAccountStars : BaseBusinessRequest
{
    /// <summary>
    /// Number of Telegram Stars to transfer; 1-10000
    /// </summary>
    public int StarCount { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
