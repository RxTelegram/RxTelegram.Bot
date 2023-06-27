using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to change the bot's menu button in a private chat, or the default menu button. Returns True on success.
/// </summary>
public class SetChatMenuButton: BaseRequest
{
    /// <summary>
    /// A JSON-serialized object for the new bot's menu button. Defaults to MenuButtonDefault
    /// </summary>
    public MenuButton MenuButton { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}