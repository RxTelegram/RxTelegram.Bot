namespace RxTelegram.Bot.Interface.Setup;

/// <summary>
/// Use this method to remove webhook integration if you decide to switch back to getUpdates.
/// </summary>
public class DeleteWebhook
{
    /// <summary>
    /// Pass True to drop all pending updates
    /// </summary>
    public bool DropPendingUpdates { get; set; }
}