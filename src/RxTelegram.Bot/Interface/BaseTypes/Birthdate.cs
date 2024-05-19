namespace RxTelegram.Bot.Interface.BaseTypes;

public class Birthdate
{
    /// <summary>
    /// Day of the user's birth; 1-31
    /// </summary>
    public int Day { get; set; }

    /// <summary>
    /// Month of the user's birth; 1-12
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Optional. Year of the user's birth
    /// </summary>
    public int? Year { get; set; }
}
