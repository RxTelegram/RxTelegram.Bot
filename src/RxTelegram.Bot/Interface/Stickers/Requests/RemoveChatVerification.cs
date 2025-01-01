using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Removes verification from a chat that is currently verified on behalf of the organization represented by the bot.
/// Returns True on success.
/// </summary>
public class RemoveChatVerification : BaseValidation
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public ChatId ChatId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
