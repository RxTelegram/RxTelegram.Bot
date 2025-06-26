using RxTelegram.Bot.Interface.Story.Enums;

namespace RxTelegram.Bot.Interface.Story;

public class StoryAreaTypeWeather
{
    /// <summary>
    /// Type of the area, always "weather"
    /// </summary>
    public StoryAreaType Type => StoryAreaType.Weather;

    /// <summary>
    /// Temperature, in degree Celsius
    /// </summary>
    public float Temperature { get; set; }

    /// <summary>
    /// Emoji representing the weather
    /// </summary>
    public string Emoji { get; set; }

    /// <summary>
    /// A color of the area background in the ARGB format
    /// </summary>
    public int BackgroundColor { get; set; }
}
