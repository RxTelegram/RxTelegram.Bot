using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Story.Requests;

using System.Collections.Generic;
using BaseTypes;

/// <summary>
/// Edits a story previously posted by the bot on behalf of a managed business account. Requires the can_manage_stories business bot right.
/// Returns Story on success.
/// </summary>
public class EditStory : BaseBusinessRequest
{
    /// <summary>
    /// Unique identifier of the story to edit
    /// </summary>
    public int StoryId { get; set; }

    /// <summary>
    /// Content of the story
    /// </summary>
    public InputStoryContent Content { get; set; }

    /// <summary>
    /// Optional. Caption of the story, 0-2048 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the story caption. See formatting options for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized list of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized list of clickable areas to be shown on the story
    /// </summary>
    public List<StoryArea> Areas { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
