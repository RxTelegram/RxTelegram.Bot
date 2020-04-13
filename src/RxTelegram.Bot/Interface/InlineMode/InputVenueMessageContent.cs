using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode
{
    /// <summary>
    /// Represents the content of a venue message to be sent as the result of an inline query.
    /// </summary>
    public class InputVenueMessageContent : InputMessageContent
    {
        /// <summary>
        /// Latitude of the venue in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the venue in degrees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Optional. Foursquare identifier of the venue, if known
        /// </summary>
        public string FoursquareId { get; set; }

        /// <summary>
        /// Optional. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”,
        /// “arts_entertainment/aquarium” or “food/icecream”.)
        /// </summary>
        public string FoursquareType { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
