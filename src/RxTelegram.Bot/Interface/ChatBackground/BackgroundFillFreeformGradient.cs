using System.Collections.Generic;
using RxTelegram.Bot.Interface.ChatBackground.Enums;

namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is a freeform gradient that rotates after every message in the chat.
/// </summary>
public class BackgroundFillFreeformGradient : BackgroundFill
{
    /// <summary>
    /// Type of the background fill, always “freeform_gradient”
    /// </summary>
    public override BackgroundFillTypes Type { get; set; } = BackgroundFillTypes.FreeformGradient;

    /// <summary>
    /// A list of the 3 or 4 base colors that are used to generate the freeform gradient in the RGB24 format
    /// </summary>
    public List<int> Colors { get; set; }
}
