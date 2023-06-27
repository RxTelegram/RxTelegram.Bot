using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to clear the list of pinned messages in a chat.
/// If the chat is not a private chat, the bot must be an administrator in the chat for this to work and must have the
/// 'can_pin_messages' admin right in a supergroup or 'can_edit_messages' admin right in a channel.
/// Returns True on success.
/// </summary>
public class UnpinAllChatMessages : BaseRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}