using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Setup
{
    public class SetWebhook : BaseValidation
    {
        /// <summary>
        /// Webhook URL, may be empty if webhook is not set up
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// True, if a custom certificate was provided for webhook certificate checks
        /// </summary>
        public InputFile Certificate { get; set; }

        /// <summary>
        /// The fixed IP address which will be used to send webhook requests instead of the IP address resolved through DNS
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
        /// </summary>
        public int? MaxConnections { get; set; }

        /// <summary>
        /// A list of update types the bot is subscribed to. Defaults to all update types
        /// </summary>
        public IEnumerable<UpdateType> AllowedUpdates { get; set; }

        /// <summary>
        /// Pass True to drop all pending updates
        /// </summary>
        public bool? DropPendingUpdates { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
