namespace RxTelegram.Bot.Interface.Story;

/// <summary>
/// Describes the position of a clickable area within a story.
/// </summary>
public class StoryAreaPosition
{
    /// <summary>
    /// The abscissa of the area's center, as a percentage of the media width
    /// </summary>
    public float XPercentage { get; set; }

    /// <summary>
    /// The ordinate of the area's center, as a percentage of the media height
    /// </summary>
    public float YPercentage { get; set; }

    /// <summary>
    /// The width of the area's rectangle, as a percentage of the media width
    /// </summary>
    public float WidthPercentage { get; set; }

    /// <summary>
    /// The height of the area's rectangle, as a percentage of the media height
    /// </summary>
    public float HeightPercentage { get; set; }

    /// <summary>
    /// The clockwise rotation angle of the rectangle, in degrees; 0-360
    /// </summary>
    public float RotationAngle { get; set; }

    /// <summary>
    /// The radius of the rectangle corner rounding, as a percentage of the media width
    /// </summary>
    public float CornerRadiusPercentage { get; set; }
}
