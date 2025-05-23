using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to an article or web page.
/// </summary>
public class InlineQueryResultArticle : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "article";

    /// <summary>
    /// Optional.
    /// URL of the result
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Optional.
    /// Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional.
    /// Url of the thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional.
    /// Thumbnail width
    /// </summary>
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional.
    /// Thumbnail height
    /// </summary>
    public int? ThumbnailHeight { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
