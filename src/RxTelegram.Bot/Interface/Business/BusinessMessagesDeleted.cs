using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Business;

/// <summary>
/// This object is received when messages are deleted from a connected business account.
/// </summary>
public class BusinessMessagesDeleted
{
    /// <summary>
    /// Unique identifier of the business connection
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Information about a chat in the business account. The bot may not have access to the chat or the corresponding user.
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// A JSON-serialized list of identifiers of deleted messages in the chat of the business account
    /// </summary>
    public List<int> MessageIds { get; set; }
}
