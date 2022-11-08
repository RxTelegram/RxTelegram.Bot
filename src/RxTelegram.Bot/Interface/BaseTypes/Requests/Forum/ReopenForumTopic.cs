using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Forum;

/// <summary>
/// Use this method to reopen a closed topic in a forum supergroup chat.
/// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights,
/// unless it is the creator of the topic.
/// Returns True on success.
/// </summary>
public class ReopenForumTopic : BaseRequest
{
    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    public int MessageThreadId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
