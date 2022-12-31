using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.GeneralForum;

/// <summary>
/// Use this method to reopen a closed 'General' topic in a forum supergroup chat.
/// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
/// The topic will be automatically unhidden if it was hidden.
/// </summary>
public class ReopenGeneralForumTopic : BaseRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}
