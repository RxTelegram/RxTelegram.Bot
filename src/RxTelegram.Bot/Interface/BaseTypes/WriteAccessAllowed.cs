namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a service message about a user allowing a bot added to the attachment menu to write messages.
/// Currently holds no information.
/// </summary>
public class WriteAccessAllowed
{
    /// <summary>
    /// Optional. Name of the Web App which was launched from a link
    /// </summary>
    public string WebAppName { get; set; }
}
