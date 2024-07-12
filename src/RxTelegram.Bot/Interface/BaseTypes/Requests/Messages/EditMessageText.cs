using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to edit text and game messages. On success, if edited message is sent by the bot, the edited Message is returned,
/// otherwise True is returned.
/// </summary>
public class EditMessageText : BaseTextRequest
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message to be edited was sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Optional
    /// Required if inline_message_id is not specified. Identifier of the message to edit
    /// </summary>
    public int? MessageId { get; set; }

    /// <summary>
    /// Optional
    /// Required if chat_id and message_id are not specified. Identifier of the inline message
    /// </summary>
    public string InlineMessageId { get; set; }

    /// <summary>
    /// Required
    /// New text of the message, 1-4096 characters after entities parsing
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Link preview generation options for the message
    /// </summary>
    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    /// <summary>
    /// Optional
    /// A JSON-serialized object for an inline keyboard.
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// List of special entities that appear in message text, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> Entities { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
