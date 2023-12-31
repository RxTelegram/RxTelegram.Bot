using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The message was originally sent to a channel chat.
/// </summary>
public class MessageOriginChannel : MessageOrigin
{
    /// <summary>
    /// Date the message was sent originally in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Channel chat to which the message was originally sent
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Unique message identifier inside the chat
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Optional. Signature of the original post author
    /// </summary>
    public string AuthorSignature { get; set; }
}
