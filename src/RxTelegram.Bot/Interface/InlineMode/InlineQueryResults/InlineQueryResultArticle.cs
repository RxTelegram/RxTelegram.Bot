namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    /// Represents a link to an article or web page.
    /// </summary>
    public class InlineQueryResultArticle : BaseInlineQueryResultMedia
    {
        public override string Type { get; } = "article";

        /// <summary>
        /// Optional.
        /// URL of the result
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional.
        /// Pass True, if you don't want the URL to be shown in the message
        /// </summary>
        public bool? HideUrl { get; set; }

        /// <summary>
        /// Optional.
        /// Short description of the result
        /// </summary>
        public string Description { get; set; }

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

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
