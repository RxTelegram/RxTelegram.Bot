using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The paid media isn't available before the payment.
/// </summary>
public class PaidMediaPreview : PaidMedia
{

    /// <summary>
    /// Type of the paid media, always “preview”
    /// </summary>
    public override PaidMediaType Type { get; set; } = PaidMediaType.Preview;

    /// <summary>
    /// Optional. Media width as defined by the sender
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Optional. Media height as defined by the sender
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Optional. Duration of the media in seconds as defined by the sender
    /// </summary>
    public int Duration { get; set; }
}
