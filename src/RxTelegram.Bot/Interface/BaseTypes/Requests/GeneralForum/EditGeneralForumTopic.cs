using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.GeneralForum;

/// <summary>
/// Use this method to edit the name of the 'General' topic in a forum supergroup chat.
/// The bot must be an administrator in the chat for this to work and must have can_manage_topics administrator rights.
/// </summary>
public class EditGeneralForumTopic : BaseRequest
{
    /// <summary>
    /// New topic name, 1-128 characters
    /// </summary>
    public string Name { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
