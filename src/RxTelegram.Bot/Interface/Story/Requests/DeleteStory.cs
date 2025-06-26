using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Story.Requests;

/// <summary>
/// Deletes a story previously posted by the bot on behalf of a managed business account. Requires the can_manage_stories business bot right.
/// Returns True on success.
/// </summary>
public class DeleteStory : BaseBusinessRequest
{

    /// <summary>
    /// Unique identifier of the story to delete
    /// </summary>
    public long StoryId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
