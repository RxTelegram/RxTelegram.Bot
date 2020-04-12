using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to send information about a venue. On success, the sent Message is returned.
    /// </summary>
    public class SendVenue : BaseRequest
    {
        /// <summary>
        /// Required
        /// Latitude of the venue
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Required
        /// Longitude of the venue
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Required
        /// Name of the venue
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Required
        /// Address of the venue
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Optional
        /// Foursquare identifier of the venue
        /// </summary>
        public string FoursquareId { get; set; }

        /// <summary>
        /// Optional
        /// Foursquare type of the venue, if known.
        /// (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
        /// </summary>
        public string FoursquareType { get; set; }

        /// <summary>
        /// Optional
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup ReplyMarkup { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
