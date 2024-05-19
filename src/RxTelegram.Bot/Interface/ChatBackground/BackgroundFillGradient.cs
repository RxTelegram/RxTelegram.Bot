using RxTelegram.Bot.Interface.ChatBackground.Enums;

namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is a gradient fill.
/// </summary>
public class BackgroundFillGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “gradient”
    /// </summary>
    public override BackgroundFillTypes Type { get; set; } = BackgroundFillTypes.Gradient;

    /// <summary>
    /// Top color of the gradient in the RGB24 format
    /// </summary>
    public int TopColor { get; set; }

    /// <summary>
    /// Bottom color of the gradient in the RGB24 format
    /// </summary>
    public int BottomColor { get; set; }

    /// <summary>
    /// Clockwise rotation angle of the background fill in degrees; 0-359
    /// </summary>
    public int RotationAngle { get; set; }
}
