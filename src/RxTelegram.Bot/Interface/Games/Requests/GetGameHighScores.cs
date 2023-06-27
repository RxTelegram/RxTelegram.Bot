using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Games.Requests;

public class GetGameHighScores : BaseValidation
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
    /// </summary>
    public ChatId ChatId { get; set; }

    /// <summary>
    /// Target user id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Required if inline_message_id is not specified. Identifier of the sent message
    /// </summary>
    public int? MessageId { get; set; }

    /// <summary>
    /// Required if chat_id and message_id are not specified. Identifier of the inline message
    /// </summary>
    public string InlineMessageId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}