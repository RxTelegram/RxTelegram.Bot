namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a boost added to a chat or changed.
/// </summary>
public class ChatBoostUpdated
{
    /// <summary>
    /// Chat which was boosted
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Infomation about the chat boost
    /// </summary>
    public ChatBoost Boost { get; set; }
}
