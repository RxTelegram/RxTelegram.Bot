using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The message was originally sent on behalf of a chat to a group chat.
/// </summary>
public class MessageOriginChat : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always “chat”
    /// </summary>
    public override MessageOriginType Type { get; set; } = MessageOriginType.Chat;

    /// <summary>
    /// Date the message was sent originally in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Chat that sent the message originally
    /// </summary>
    public Chat SenderChat { get; set; }

    /// <summary>
    /// Optional. For messages originally sent by an anonymous chat administrator, original message author signature
    /// </summary>
    public string AuthorSignature { get; set; }
}
