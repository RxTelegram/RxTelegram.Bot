using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to forward multiple messages of any kind. If some of the specified messages can't be found or forwarded, they are skipped.
/// Service messages and messages with protected content can't be forwarded. Album grouping is kept for forwarded messages.
/// On success, an array of MessageId of the sent messages is returned.
/// </summary>
public class ForwardMessages : BaseRequest
{
    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Unique identifier for the chat where the original messages were sent (or channel username in the format @channelusername)
    /// </summary>
    public ChatId FromChatId { get; set; }

    /// <summary>
    /// Identifiers of 1-100 messages in the chat from_chat_id to forward. The identifiers must be specified in a strictly increasing order.
    /// </summary>
    public List<long> MessageIds { get; set; }

    /// <summary>
    /// Sends the messages silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Protects the contents of the forwarded messages from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
