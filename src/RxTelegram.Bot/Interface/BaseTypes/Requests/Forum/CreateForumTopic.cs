using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Forum;

/// <summary>
/// Use this method to create a topic in a forum supergroup chat.
/// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
/// Returns information about the created topic as a <see cref="ForumTopic"/> object.
/// </summary>
public class CreateForumTopic : BaseRequest
{
    /// <summary>
    /// Topic name, 1-128 characters
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Color of the topic icon in RGB format.
    /// Currently, must be one of 0x6FB9F0, 0xFFD67E, 0xCB86DB, 0x8EEE98, 0xFF93B2, or 0xFB6F5F
    /// </summary>
    public int IconColor { get; set; }

    /// <summary>
    /// Unique identifier of the custom emoji shown as the topic icon.
    /// Use getForumTopicIconStickers to get all allowed custom emoji identifiers.
    /// </summary>
    public string IconCustomEmojiId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
