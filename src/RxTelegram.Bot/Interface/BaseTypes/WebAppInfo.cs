namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// Contains information about a Web App.
/// </summary>
public class WebAppInfo
{
    /// <summary>
    /// An HTTPS URL of a Web App to be opened with additional data as specified in Initializing Web Apps.
    /// </summary>
    public string Url { get; set; }
}