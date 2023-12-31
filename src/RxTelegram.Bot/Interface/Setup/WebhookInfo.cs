using System;
using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.Setup;

/// <summary>
/// Contains information about the current status of a webhook.
/// </summary>
public class WebhookInfo
{
    /// <summary>
    /// Webhook URL, may be empty if webhook is not set up
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// True, if a custom certificate was provided for webhook certificate checks
    /// </summary>
    public bool HasCustomCertificate { get; set; }

    /// <summary>
    /// Number of updates awaiting delivery
    /// </summary>
    public int PendingUpdateCount { get; set; }

    /// <summary>
    /// Currently used webhook IP address
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// Unix time for the most recent error that happened when trying to deliver an update via webhook
    /// </summary>
    public DateTime? LastErrorDate { get; set; }

    /// <summary>
    /// Error message in human-readable format for the most recent error that happened when trying to
    /// deliver an update via webhook
    /// </summary>
    public string LastErrorMessage { get; set; }

    /// <summary>
    /// Unix time of the most recent error that happened when trying to synchronize available updates
    /// with Telegram datacenters
    /// </summary>
    public DateTime? LastSynchronizationErrorDate { get; set; }

    /// <summary>
    /// Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
    /// </summary>
    public int? MaxConnections { get; set; }

    /// <summary>
    /// A list of update types the bot is subscribed to. Defaults to all update types
    /// </summary>
    public IEnumerable<string> AllowedUpdates { get; set; }
}
