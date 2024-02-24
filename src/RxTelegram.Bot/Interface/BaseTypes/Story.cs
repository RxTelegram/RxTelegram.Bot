namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a message about a forwarded story in the chat.
/// </summary>
public class Story
{
    /// <summary>
    /// Unique identifier for the story in the chat
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Chat that posted the story
    /// </summary>
    public Chat Chat { get; set; }
}
