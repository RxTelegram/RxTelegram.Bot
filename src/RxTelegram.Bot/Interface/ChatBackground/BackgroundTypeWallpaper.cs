using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.ChatBackground;

public class BackgroundTypeWallpaper : BackgroundType
{
    /// <summary>
    /// Type of the background, always “wallpaper”
    /// </summary>
    public override string Type { get; } = "wallpaper";

    /// <summary>
    /// Document with the wallpaper
    /// </summary>
    public Document Document { get; set; }

    /// <summary>
    /// Dimming of the background in dark themes, as a percentage; 0-100
    /// </summary>
    public int DarkThemeDimming { get; set; }

    /// <summary>
    /// Optional. True, if the wallpaper is downscaled to fit in a 450x450 square and then box-blurred with radius 12
    /// </summary>
    public bool IsBlurred { get; set; }

    /// <summary>
    /// Optional. True, if the background moves slightly when the device is tilted
    /// </summary>
    public bool IsMoving { get; set; }
}
