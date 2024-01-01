using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about the quoted part of a message that is replied to by the given message.
/// </summary>
public class TextQuote
{
    /// <summary>
    /// Text of the quoted part of a message that is replied to by the given message
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. Special entities that appear in the quote.
    /// Currently, only bold, italic, underline, strikethrough, spoiler, and custom_emoji entities are kept in quotes.
    /// </summary>
    public List<MessageEntity> Entities { get; set; }

    /// <summary>
    /// Approximate quote position in the original message in UTF-16 code units as specified by the sender
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Optional. True, if the quote was chosen manually by the message sender. Otherwise, the quote was added automatically by the server.
    /// </summary>
    public bool IsManual { get; set; }
}
