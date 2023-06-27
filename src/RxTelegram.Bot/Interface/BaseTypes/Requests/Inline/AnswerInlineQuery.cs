using System.Collections.Generic;
using RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;

/// <summary>
/// Use this method to send answers to an inline query. On success, True is returned.
/// No more than 50 results per query are allowed.
/// </summary>
public class AnswerInlineQuery : BaseValidation
{
    /// <summary>
    /// Required
    /// Unique identifier for the answered query
    /// </summary>
    public string InlineQueryId { get; set; }

    /// <summary>
    /// Required
    /// A JSON-serialized array of results for the inline query
    /// </summary>
    public IEnumerable<BaseInlineQueryResult>  Results { get; set; }

    /// <summary>
    /// Optional
    /// The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.
    /// </summary>
    public int? CacheTime { get; set; }

    /// <summary>
    /// Optional
    /// Pass True, if results may be cached on the server side only for the user that sent the query. By default, results may be
    /// returned to any user who sends the same query
    /// </summary>
    public bool? IsPersonal { get; set; }

    /// <summary>
    /// Optional
    /// Pass the offset that a client should send in the next query with the same text to receive more results. Pass an empty string
    /// if there are no more results or if you don‘t support pagination. Offset length can’t exceed 64 bytes.
    /// </summary>
    public string NextOffset { get; set; }

    /// <summary>
    /// Optional
    /// A JSON-serialized object describing a button to be shown above inline query results
    /// </summary>
    public InlineQueryResultsButton Button { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}