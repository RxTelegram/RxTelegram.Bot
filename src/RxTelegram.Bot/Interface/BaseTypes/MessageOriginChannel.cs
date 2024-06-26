using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The message was originally sent to a channel chat.
/// </summary>
public class MessageOriginChannel : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always “channel”
    /// </summary>
    public override MessageOriginType Type { get; set; } = MessageOriginType.Channel;

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
    public int MessageId { get; set; }

    /// <summary>
    /// Optional. Signature of the original post author
    /// </summary>
    public string AuthorSignature { get; set; }

}
