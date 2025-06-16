using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Gifts a Telegram Premium subscription to the given user. Returns True on success.
/// </summary>
public class GiftPremiumSubscription : BaseValidation
{
    /// <summary>
    /// Unique identifier of the target user who will receive a Telegram Premium subscription
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Number of months the Telegram Premium subscription will be active for the user; must be one of 3, 6, or 12
    /// </summary>
    public int MonthCount { get; set; }

    /// <summary>
    /// Number of Telegram Stars to pay for the Telegram Premium subscription;
    /// must be 1000 for 3 months, 1500 for 6 months, and 2500 for 12 months
    /// </summary>
    public int StarCount { get; set; }

    /// <summary>
    /// Text that will be shown along with the service message about the subscription; 0-128 characters
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Mode for parsing entities in the text. See formatting options for more details.
    /// Entities other than “bold”, “italic”, “underline”, “strikethrough”, “spoiler”, and “custom_emoji” are ignored.
    /// </summary>
    public ParseMode TextParseMode { get; set; }

    /// <summary>
    /// A JSON-serialized list of special entities that appear in the gift text. It can be specified instead of text_parse_mode.
    /// Entities other than “bold”, “italic”, “underline”, “strikethrough”, “spoiler”, and “custom_emoji” are ignored.
    /// </summary>
    public List<MessageEntity> TextEntities { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
