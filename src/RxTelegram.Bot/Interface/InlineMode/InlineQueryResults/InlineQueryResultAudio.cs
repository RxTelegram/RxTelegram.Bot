using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

public class InlineQueryResultAudio : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "audio";

    /// <summary>
    /// A valid URL for the audio file
    /// </summary>
    public string AudioUrl { get; set; }

    /// <summary>
    /// Optional.
    /// Performer
    /// </summary>
    public string Performer { get; set; }

    /// <summary>
    /// Optional.
    /// Audio duration in seconds
    /// </summary>
    public int? AudioDuration { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    /// fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
