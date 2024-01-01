using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

public class MessageOriginHiddenUser : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always “hidden_user”
    /// </summary>
    public override MessageOriginType Type { get; set; } = MessageOriginType.HiddenUser;

    /// <summary>
    /// Date the message was sent originally in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Name of the user that sent the message originally
    /// </summary>
    public string SenderUserName { get; set; }
}
