namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents an inline keyboard button that copies specified text to the clipboard.
/// </summary>
public class CopyTextButton
{
    /// <summary>
    /// The text to be copied to the clipboard; 1-256 characters
    /// </summary>
    public string Text { get; set; }
}
