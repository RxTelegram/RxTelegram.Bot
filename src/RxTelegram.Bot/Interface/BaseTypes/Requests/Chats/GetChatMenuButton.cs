using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to get the current value of the bot's menu button in a private chat, or the default menu button.
/// Returns MenuButton on success.
/// </summary>
public class GetChatMenuButton : BaseRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}