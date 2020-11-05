using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode
{
    /// <summary>
    /// Represents the content of a location message to be sent as the result of an inline query.
    /// </summary>
    public class InputLocationMessageContent : InputMessageContent
    {
        /// <summary>
        /// Latitude of the location in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location in degrees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The radius of uncertainty for the location, measured in meters; 0-1500
        /// </summary>
        public double HorizontalAccuracy { get; set; }

        /// <summary>
        /// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        public int LivePeriod { get; set; }

        /// <summary>
        /// For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
        /// </summary>
        public int? Heading { get; set; }

        /// <summary>
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
        /// Must be between 1 and 100000 if specified.
        /// </summary>
        public int? ProximityAlertRadius { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
