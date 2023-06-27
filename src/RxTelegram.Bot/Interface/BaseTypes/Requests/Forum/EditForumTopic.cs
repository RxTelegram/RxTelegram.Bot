using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Forum;

/// <summary>
/// Use this method to create a topic in a forum supergroup chat.
/// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
/// Returns information about the created topic as a <see cref="ForumTopic"/> object.
/// </summary>
public class EditForumTopic : BaseRequest
{
    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// New topic name, 1-128 characters
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// New unique identifier of the custom emoji shown as the topic icon.
    /// Use <see cref="ITelegramBot.GetForumTopicIconStickers"/> to get all allowed custom emoji identifiers.
    /// </summary>
    public string IconCustomEmojiId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
