using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about a poll.
/// </summary>
public class Poll
{
    /// <summary>
    /// Unique poll identifier
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Poll question, 1-255 characters
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// List of poll options
    /// </summary>
    public IEnumerable<PollOption> Options { get; set; }

    /// <summary>
    /// Total number of users that voted in the poll
    /// </summary>
    public int TotalVoterCount { get; set; }

    /// <summary>
    /// True, if the poll is closed
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// True, if the poll is anonymous
    /// </summary>
    public bool IsAnonymous { get; set; }

    /// <summary>
    /// Poll type, currently can be “regular” or “quiz”
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// True, if the poll allows multiple answers
    /// </summary>
    public bool AllowsMultipleAnswers { get; set; }

    /// <summary>
    /// Optional. 0-based identifier of the correct answer option. Available only for polls in the quiz mode,
    /// which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot.
    /// </summary>
    public int? CorrectOptionId { get; set; }

    /// <summary>
    /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll,
    /// 0-200 characters
    /// </summary>
    public string Explanation { get; set; }

    /// <summary>
    /// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the explanation
    /// </summary>
    public IEnumerable<MessageEntity> ExplanationEntities { get; set; }

    /// <summary>
    /// Optional. Amount of time in seconds the poll will be active after creation
    /// </summary>
    public int? OpenPeriod { get; set; }

    /// <summary>
    /// Optional. Point in time (Unix timestamp) when the poll will be automatically closed
    /// </summary>
    public int? CloseDate { get; set; }
}