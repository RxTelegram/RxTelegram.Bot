using RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;

/// <summary>
/// Stores a message that can be sent by a user of a Mini App. Returns a PreparedInlineMessage object.
/// </summary>
public class SavePreparedInlineMessage : BaseValidation
{
    /// <summary>
    /// Unique identifier of the target user that can use the prepared message
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// A JSON-serialized object describing the message to be sent
    /// </summary>
    public BaseInlineQueryResult Result { get; set; }

    /// <summary>
    /// Pass True if the message can be sent to private chats with users
    /// </summary>
    public bool AllowUserChats { get; set; }

    /// <summary>
    /// Pass True if the message can be sent to private chats with bots
    /// </summary>
    public bool AllowBotChats { get; set; }

    /// <summary>
    /// Pass True if the message can be sent to group and supergroup chats
    /// </summary>
    public bool AllowGroupChats { get; set; }

    /// <summary>
    /// Pass True if the message can be sent to channel chats
    /// </summary>
    public bool AllowChannelChats { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
