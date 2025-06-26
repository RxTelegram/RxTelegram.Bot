using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes a story area pointing to a location. Currently, a story can have up to 10 location areas.
/// </summary>
public class StoryAreaTypeLocation
{
    /// <summary>
    /// Type of the area, always "location"
    /// </summary>
    public StoryAreaType Type => StoryAreaType.Location;

    /// <summary>
    /// Location latitude in degrees
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Location longitude in degrees
    /// </summary>
    public float Longitude { get; set; }

    /// <summary>
    /// Optional. Address of the location
    /// </summary>
    public LocationAddress? Address { get; set; }
}
