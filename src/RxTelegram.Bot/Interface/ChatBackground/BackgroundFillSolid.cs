using RxTelegram.Bot.Interface.ChatBackground.Enums;

namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is filled using the selected color.
/// </summary>
public class BackgroundFillSolid : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “solid”
    /// </summary>
    public override BackgroundFillTypes Type { get; set; } = BackgroundFillTypes.Solid;

    /// <summary>
    /// The color of the background fill in the RGB24 format
    /// </summary>
    public long Color { get; set; }
}
