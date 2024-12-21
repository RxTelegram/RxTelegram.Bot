using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Users;

/// <summary>
/// Changes the emoji status for a given user that previously allowed the bot to manage their
/// emoji status via the Mini App method <see cref="TelegramBot.RequestEmojiStatusAccess"/> . Returns True on success.
/// </summary>
public class SetUserEmojiStatus : BaseValidation
{
    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Custom emoji identifier of the emoji status to set. Pass an empty string to remove the status.
    /// </summary>
    public string EmojiStatusCustomEmojiId { get; set; }

    /// <summary>
    /// Expiration date of the emoji status, if any
    /// </summary>
    public int EmojiStatusExpirationDate { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
