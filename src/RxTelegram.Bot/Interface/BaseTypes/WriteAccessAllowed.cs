namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a service message about a user allowing a bot added to the attachment menu to write messages.
/// </summary>
public class WriteAccessAllowed
{
    /// <summary>
    /// Optional. True, if the access was granted after the user accepted an explicit request from a Web App sent by the method requestWriteAccess
    /// </summary>
    public bool FromRequest { get; set; }

    /// <summary>
    /// Optional. Name of the Web App which was launched from a link
    /// </summary>
    public string WebAppName { get; set; }

    /// <summary>
    /// Optional. True, if the access was granted when the bot was added to the attachment or side menu
    /// </summary>
    public bool FromAttachmentMenu { get; set; }
}
