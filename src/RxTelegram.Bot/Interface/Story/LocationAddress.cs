namespace RxTelegram.Bot.Interface.Story;

public class LocationAddress
{
    /// <summary>
    /// The two-letter ISO 3166-1 alpha-2 country code of the country where the location is located
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Optional. State of the location
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Optional. City of the location
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Optional. Street address of the location
    /// </summary>
    public string? Street { get; set; }
}
