using System.Collections.Generic;
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
        /// Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
        /// </summary>
        public int? MaxConnections { get; set; }

        /// <summary>
        /// A list of update types the bot is subscribed to. Defaults to all update types
        /// </summary>
        public IEnumerable<string> AllowedUpdates { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
