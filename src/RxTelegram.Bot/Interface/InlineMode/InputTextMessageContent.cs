using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode;

/// <summary>
/// Represents the content of a text message to be sent as the result of an inline query.
/// </summary>
public class InputTextMessageContent: InputMessageContent
{
    /// <summary>
    /// Text of the message to be sent, 1-4096 characters
    /// </summary>
    public string MessageText { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text
    /// or inline URLs in your bot's message.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// List of special entities that appear in message text, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> Entities { get; set; }

    /// <summary>
    /// Optional. Link preview generation options for the message
    /// </summary>
    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
