using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Transfers an owned unique gift to another user. Requires the can_transfer_and_upgrade_gifts business bot right.
/// Requires can_transfer_stars business bot right if the transfer is paid. Returns True on success.
/// </summary>
public class TransferGift : BaseBusinessRequest
{

    /// <summary>
    /// Unique identifier of the regular gift that should be transferred
    /// </summary>
    public string OwnedGiftId { get; set; }

    /// <summary>
    /// Unique identifier of the chat which will own the gift. The chat must be active in the last 24 hours.
    /// </summary>
    public long NewOwnerChatId { get; set; }

    /// <summary>
    /// The amount of Telegram Stars that will be paid for the transfer from the business account balance.
    /// If positive, then the can_transfer_stars business bot right is required.
    /// </summary>
    public int? StarCount { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
