using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about one answer option in a poll to send.
/// </summary>
public class InputPollOption
{
    /// <summary>
    /// Option text, 1-100 characters
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the text. See formatting options for more details.
    /// Currently, only custom emoji entities are allowed
    /// </summary>
    public string TextParseMode { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized list of special entities that appear in the poll option text.
    /// It can be specified instead of <see cref="TextParseMode"/>
    /// </summary>
    public List<MessageEntity> TextEntities { get; set; }
}
