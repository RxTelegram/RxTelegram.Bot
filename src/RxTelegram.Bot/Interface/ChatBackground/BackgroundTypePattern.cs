using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.ChatBackground.Enums;

namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is a PNG or TGV (gzipped subset of SVG with MIME type “application/x-tgwallpattern”) pattern to be combined with the background fill chosen by the user.
/// </summary>
public class BackgroundTypePattern : BackgroundType
{
    /// <summary>
    /// Type of the background, always “pattern”
    /// </summary>
    public override BackgroundTypes Type { get; set; } = BackgroundTypes.Pattern;

    /// <summary>
    /// Document with the pattern
    /// </summary>
    public Document Document { get; set; }

    /// <summary>
    /// The background fill that is combined with the pattern
    /// </summary>
    public BackgroundFill Fill { get; set; }

    /// <summary>
    /// Intensity of the pattern when it is shown above the filled background; 0-100
    /// </summary>
    public int Intensity { get; set; }

    /// <summary>
    /// Optional. True, if the background fill must be applied only to the pattern itself. All other pixels are black in this case. For dark themes only
    /// </summary>
    public bool IsInverted { get; set; }

    /// <summary>
    /// Optional. True, if the background moves slightly when the device is tilted
    /// </summary>
    public bool IsMoving { get; set; }
}
