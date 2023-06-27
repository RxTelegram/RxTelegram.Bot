using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to an MP3 audio file stored on the Telegram servers. By default, this audio file will be sent by the user.
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
/// </summary>
public class InlineQueryResultCachedAudio : BaseInlineQueryResult
{
    public string Id { get; set; }

    public override string Type { get; } = "audio";

    /// <summary>
    /// A valid file identifier for the audio file
    /// </summary>
    public string AudioFileId { get; set; }

    /// <summary>
    /// Optional.
    /// Caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    /// fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// Content of the message to be sent
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional.
    /// Inline keyboard attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}