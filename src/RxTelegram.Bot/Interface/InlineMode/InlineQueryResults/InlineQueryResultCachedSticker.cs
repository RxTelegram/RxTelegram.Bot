using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;

/// <summary>
/// Represents a link to a sticker stored on the Telegram servers. By default, this sticker will be sent by the user. Alternatively,
/// you can use input_message_content to send a message with the specified content instead of the sticker.
/// </summary>
public class InlineQueryResultCachedSticker : BaseInlineQueryResult
{
    public override string Type { get; } = "sticker";

    /// <summary>
    /// A valid file identifier of the sticker
    /// </summary>
    public string StickerFileId { get; set; }

    /// <summary>
    /// Content of the message to be sent
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    public string Id { get; set; }

    /// <summary>
    /// Optional.
    /// Inline keyboard attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}