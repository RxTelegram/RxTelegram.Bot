using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

public class MessageOriginHiddenUser : MessageOrigin
{
    /// <summary>
    /// Date the message was sent originally in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Name of the user that sent the message originally
    /// </summary>
    public string SenderUserName { get; set; }
}
