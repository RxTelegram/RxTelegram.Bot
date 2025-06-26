using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Story.Requests;

/// <summary>
/// Posts a story on behalf of a managed business account. Requires the can_manage_stories business bot right. Returns Story on success.
/// </summary>
public class PostStory : BaseBusinessRequest
{
    /// <summary>
    /// Content of the story
    /// </summary>
    public InputStoryContent Content { get; set; }

    /// <summary>
    /// Period after which the story is moved to the archive, in seconds; must be one of 6 * 3600, 12 * 3600, 86400, or 2 * 86400
    /// </summary>
    public int ActivePeriod { get; set; }

    /// <summary>
    /// Optional. Caption of the story, 0-2048 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the story caption. See formatting options for more details.
    /// </summary>
    public string? ParseMode { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized list of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized list of clickable areas to be shown on the story
    /// </summary>
    public List<StoryArea>? Areas { get; set; }

    /// <summary>
    /// Optional. Pass True to keep the story accessible after it expires
    /// </summary>
    public bool? PostToChatPage { get; set; }

    /// <summary>
    /// Optional. Pass True if the content of the story must be protected from forwarding and screenshotting
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
