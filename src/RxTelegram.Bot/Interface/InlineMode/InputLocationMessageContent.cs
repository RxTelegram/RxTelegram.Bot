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
        /// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        public int LivePeriod { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
