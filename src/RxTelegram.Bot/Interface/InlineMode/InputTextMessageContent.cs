using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode
{
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
    /// Optional. Disables link previews for links in the sent message
    /// </summary>
    public bool DisableWebPagePreview { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
    }
}
