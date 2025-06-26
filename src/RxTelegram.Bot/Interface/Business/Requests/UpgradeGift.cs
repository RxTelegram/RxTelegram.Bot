using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Upgrades a given regular gift to a unique gift. Requires the can_transfer_and_upgrade_gifts business bot right.
/// Additionally requires the can_transfer_stars business bot right if the upgrade is paid. Returns True on success.
/// </summary>
public class UpgradeGift : BaseBusinessRequest
{
    /// <summary>
    /// Unique identifier of the regular gift that should be upgraded to a unique one
    /// </summary>
    public string OwnedGiftId { get; set; }

    /// <summary>
    /// Pass True to keep the original gift text, sender and receiver in the upgraded gift
    /// </summary>
    public bool? KeepOriginalDetails { get; set; }

    /// <summary>
    /// The amount of Telegram Stars that will be paid for the upgrade from the business account balance.
    /// If gift.prepaid_upgrade_star_count > 0, then pass 0, otherwise, the can_transfer_stars business bot right is required and gift.upgrade_star_count must be passed.
    /// </summary>
    public int? StarCount { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
