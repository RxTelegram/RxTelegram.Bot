namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a point on the map.
/// </summary>
public class Location
{
    /// <summary>
    /// Longitude as defined by sender
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Latitude as defined by sender
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public double HorizontalAccuracy { get; set; }

    /// <summary>
    /// Time relative to the message sending date, during which the location can be updated, in seconds. For active live locations only.
    /// </summary>
    public int? LivePeriod { get; set; }

    /// <summary>
    /// The direction in which user is moving, in degrees; 1-360. For active live locations only.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// Maximum distance for proximity alerts about approaching another chat member, in meters. For sent live locations only.
    /// </summary>
    public int ProximityAlertRadius { get; set; }
}