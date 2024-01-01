using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The message was originally sent by a known user.
/// </summary>

public class MessageOriginUser : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always “user”
    /// </summary>
    public override MessageOriginType Type { get; set; } = MessageOriginType.User;

    /// <summary>
    /// Date the message was sent originally in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// User that sent the message originally
    /// </summary>
    public User SenderUser { get; set; }
}
