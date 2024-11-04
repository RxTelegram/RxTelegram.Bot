using System;
using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
/// Use this method to send a native poll. On success, the sent Message is returned.
/// </summary>
public class SendPoll : BaseRequest, IProtectContent, IAllowPaidBroadcast
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Required
    /// Poll question, 1-255 characters
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// Mode for parsing entities in the question. See formatting options for more details.
    /// urrently, only custom emoji entities are allowed
    /// </summary>
    public string QuestionParseMode { get; set; }

    /// <summary>
    /// A JSON-serialized list of special entities that appear in the poll question. It can be specified instead of question_parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> QuestionEntities { get; set; }

    /// <summary>
    /// Required
    /// A JSON-serialized list of answer options, 2-10 strings 1-100 characters each
    /// </summary>
    public IEnumerable<InputPollOption>  Options { get; set; }

    /// <summary>
    /// Optional
    /// True, if the poll needs to be anonymous, defaults to True
    /// </summary>
    public bool? IsAnonymous { get; set; }

    /// <summary>
    /// Type
    /// Poll type, “quiz” or “regular”, defaults to “regular”
    /// </summary>
    public PollType Type { get; set; } = PollType.Regular;

    /// <summary>
    /// Optional
    /// True, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to False
    /// </summary>
    public bool? AllowsMultipleAnswers { get; set; }

    /// <summary>
    /// Optional
    /// 0-based identifier of the correct answer option, required for polls in quiz mode
    /// </summary>
    public int? CorrectOptionId { get; set; }

    /// <summary>
    /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters
    /// with at most 2 line feeds after entities parsing
    /// </summary>
    public string Explanation { get; set; }

    /// <summary>
    /// Mode for parsing entities in the explanation. See formatting options for more details.
    /// </summary>
    public ParseMode ExplanationParseMode { get; set; }

    /// <summary>
    /// Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with close_date.
    /// </summary>
    public int? OpenPeriod { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when the poll will be automatically closed. Must be at least 5 and no more than 600 seconds in
    /// the future. Can't be used together with open_period.
    /// </summary>
    public DateTime? CloseDate { get; set; }

    /// <summary>
    /// Optional
    /// Pass True, if the poll needs to be immediately closed. This can be useful for poll preview.
    /// </summary>
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove
    /// reply keyboard or to force a reply from the user.
    /// </summary>
    public IReplyMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// List of special entities that appear in the poll explanation, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> ExplanationEntities { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    /// <summary>
    /// Pass True to allow up to 1000 messages per second, ignoring broadcasting limits for a fee of 0.1 Telegram Stars per message.
    /// The relevant Stars will be withdrawn from the bot's balance
    /// </summary>
    public bool? AllowPaidBroadcast { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
