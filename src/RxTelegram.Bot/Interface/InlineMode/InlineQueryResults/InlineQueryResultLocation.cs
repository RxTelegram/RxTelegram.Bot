namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a location on a map. By default, the location will be sent by the user. Alternatively, you can use input_message_content
    /// to send a message with the specified content instead of the location.
    /// </summary>
    public class InlineQueryResultLocation : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "location";

        /// <summary>
        /// Location latitude in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Location longitude in degrees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Optional.
        /// Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        public int? LivePeriod { get; set; }

        /// <summary>
        /// Optional.
        /// Url of the thumbnail for the result
        /// </summary>
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Optional.
        /// Thumbnail width
        /// </summary>
        public int? ThumbWidth { get; set; }

        /// <summary>
        /// Optional.
        /// Thumbnail height
        /// </summary>
        public int? ThumbHeight { get; set; }
    }
}
