using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to copy messages of any kind. If some of the specified messages can't be found or copied, they are skipped.
/// Service messages, giveaway messages, giveaway winners messages, and invoice messages can't be copied.
/// A quiz poll can be copied only if the value of the field correct_option_id is known to the bot.
/// The method is analogous to the method forwardMessages, but the copied messages don't have a link to the original message.
/// Album grouping is kept for copied messages. On success, an array of MessageId of the sent messages is returned.
/// </summary>
public class CopyMessages : BaseRequest
{
    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public long MessageThreadId { get; set; }

    /// <summary>
    /// Unique identifier for the chat where the original messages were sent (or channel username in the format @channelusername)
    /// </summary>
    public ChatId FromChatId { get; set; }

    /// <summary>
    /// Identifiers of 1-100 messages in the chat from_chat_id to copy. The identifiers must be specified in a strictly increasing order.
    /// </summary>
    public List<long> MessageIds { get; set; }

    /// <summary>
    /// Sends the messages silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Protects the contents of the sent messages from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// Pass True to copy the messages without their captions
    /// </summary>
    public bool? RemoveCaption { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
