namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Describes an amount of Telegram Stars.
/// </summary>
public class StarAmount
{
    /// <summary>
    /// Integer amount of Telegram Stars, rounded to 0; can be negative
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Optional. The number of 1/1000000000 shares of Telegram Stars;
    /// from -999999999 to 999999999; can be negative if and only if amount is non-positive
    /// </summary>
    public int NanostarAmount { get; set; }
}
