namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Returns the gifts received and owned by a managed business account. Requires the can_view_gifts_and_stars business bot right.
/// Returns OwnedGifts on success.
/// </summary>
public class GetBusinessAccountGifts
{
    /// <summary>
    /// Unique identifier of the business connection
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Pass True to exclude gifts that aren't saved to the account's profile page
    /// </summary>
    public bool? ExcludeUnsaved { get; set; }

    /// <summary>
    /// Pass True to exclude gifts that are saved to the account's profile page
    /// </summary>
    public bool? ExcludeSaved { get; set; }

    /// <summary>
    /// Pass True to exclude gifts that can be purchased an unlimited number of times
    /// </summary>
    public bool? ExcludeUnlimited { get; set; }

    /// <summary>
    /// Pass True to exclude gifts that can be purchased a limited number of times
    /// </summary>
    public bool? ExcludeLimited { get; set; }

    /// <summary>
    /// Pass True to exclude unique gifts
    /// </summary>
    public bool? ExcludeUnique { get; set; }

    /// <summary>
    /// Pass True to sort results by gift price instead of send date. Sorting is applied before pagination.
    /// </summary>
    public bool? SortByPrice { get; set; }

    /// <summary>
    /// Offset of the first entry to return as received from the previous request; use empty string to get the first chunk of results
    /// </summary>
    public string Offset { get; set; }

    /// <summary>
    /// The maximum number of gifts to be returned; 1-100. Defaults to 100
    /// </summary>
    public int? Limit { get; set; }
}
