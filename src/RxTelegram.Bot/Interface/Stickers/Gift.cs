namespace RxTelegram.Bot.Interface.Stickers;

/// <summary>
/// This object represents a gift that can be sent by the bot.
/// </summary>
public class Gift
{
    /// <summary>
    /// Unique identifier of the gift
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The sticker that represents the gift
    /// </summary>
    public Sticker Sticker { get; set; }

    /// <summary>
    /// The number of Telegram Stars that must be paid to send the sticker
    /// </summary>
    public int StarCount { get; set; }

    /// <summary>
    /// Optional. The total number of the gifts of this type that can be sent; for limited gifts only
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Optional. The number of remaining gifts of this type that can be sent; for limited gifts only
    /// </summary>
    public int RemainingCount { get; set; }
}
