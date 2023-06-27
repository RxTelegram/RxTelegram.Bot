using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a location on a map. By default, the location will be sent by the user. Alternatively, you can use input_message_content
/// to send a message with the specified content instead of the location.
/// </summary>
public class InlineQueryResultLocation : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "location";

    /// <summary>
    /// Location latitude in degrees
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Location longitude in degrees
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public double HorizontalAccuracy { get; set; }

    /// <summary>
    /// Optional.
    /// Period in seconds for which the location can be updated, should be between 60 and 86400.
    /// </summary>
    public int? LivePeriod { get; set; }

    /// <summary>
    /// For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
    /// Must be between 1 and 100000 if specified.
    /// </summary>
    public int? ProximityAlertRadius { get; set; }

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