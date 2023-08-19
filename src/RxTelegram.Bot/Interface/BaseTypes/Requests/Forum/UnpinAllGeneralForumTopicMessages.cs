using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Forum;

/// <summary>
/// Use this method to clear the list of pinned messages in a General forum topic.
/// The bot must be an administrator in the chat for this to work and must have the can_pin_messages administrator right in the supergroup.
/// Returns True on success.
/// </summary>
public class UnpinAllGeneralForumTopicMessages : BaseRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}
