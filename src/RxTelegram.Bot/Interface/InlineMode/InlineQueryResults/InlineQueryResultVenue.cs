using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use input_message_content to send a
/// message with the specified content instead of the venue.
/// </summary>
public class InlineQueryResultVenue : BaseInlineQueryResultMedia
{
    public override string Type { get; } = "venue";

    /// <summary>
    /// Location latitude in degrees
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Location longitude in degrees
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Optional.
    /// Foursquare identifier of the venue if known
    /// </summary>
    public string FoursquareId { get; set; }

    /// <summary>
    /// Optional.
    /// Foursquare type of the venue, if known.
    /// (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    public string FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    public string GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// </summary>
    public string GooglePlaceType { get; set; }

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
