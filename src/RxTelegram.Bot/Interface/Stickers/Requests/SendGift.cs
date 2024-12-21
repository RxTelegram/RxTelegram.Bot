using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests;

/// <summary>
/// Sends a gift to the given user. The gift can't be converted to Telegram Stars by the user. Returns True on success.
/// </summary>
public class SendGift : BaseValidation
{
    /// <summary>
    /// Unique identifier of the target user that will receive the gift
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Identifier of the gift
    /// </summary>
    public string GiftId { get; set; }

    /// <summary>
    /// Text that will be shown along with the gift; 0-255 characters
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Mode for parsing entities in the text.
    /// </summary>
    public string TextParseMode { get; set; }

    /// <summary>
    /// A JSON-serialized list of special entities that appear in the gift text. It can be specified instead of text_parse_mode.
    /// Entities other than “bold”, “italic”, “underline”, “strikethrough”, “spoiler”, and “custom_emoji” are ignored.
    /// </summary>
    public List<MessageEntity> TextEntities { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}