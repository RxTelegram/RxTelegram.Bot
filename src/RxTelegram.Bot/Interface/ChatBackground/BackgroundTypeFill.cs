namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is automatically filled based on the selected colors.
/// </summary>
public class BackgroundTypeFill : BackgroundType
{
    /// <summary>
    /// Type of the background, always “fill”
    /// </summary>
    public override string Type { get; } = "fill";

    /// <summary>
    /// The background fill
    /// </summary>
    public BackgroundFill Fill { get; set; }

    /// <summary>
    /// Dimming of the background in dark themes, as a percentage; 0-100
    /// </summary>
    public int DarkThemeDimming { get; set; }
}
