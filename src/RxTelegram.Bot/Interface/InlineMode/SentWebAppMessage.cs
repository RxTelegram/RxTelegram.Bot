using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.InlineMode;

/// <summary>
/// Contains information about an inline message sent by a Web App on behalf of a user.
/// </summary>
public class SentWebAppMessage
{
    /// <summary>
    /// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message.
    /// </summary>
    public WebAppInfo InlineMessageId { get; set; }
}