using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode.InlineQueryResults
{
    /// <summary>
    ///     Represents a contact with a phone number. By default, this contact will be sent by the user. Alternatively, you can use
    ///     input_message_content to send a message with the specified content instead of the contact.
    /// </summary>
    public class InlineQueryResultContact : BaseInlineQueryResult
    {
        public string Id { get; set; }

        public override string Type { get; } = "contact";

        /// <summary>
        ///     Contact's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Contact's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Optional.
        ///     Contact's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Optional.
        ///     Additional data about the contact in the form of a vCard, 0-2048 bytes
        /// </summary>
        public string Vcard { get; set; }

        /// <summary>
        ///     Optional.
        ///     Url of the thumbnail for the result
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        ///     Optional.
        ///     Thumbnail width
        /// </summary>
        public int? ThumbnailWidth { get; set; }

        /// <summary>
        ///     Optional.
        ///     Thumbnail height
        /// </summary>
        public int? ThumbnailHeight { get; set; }

        /// <summary>
        ///     Optional.
        ///     Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        ///     Content of the message to be sent
        /// </summary>
        public InputMessageContent InputMessageContent { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
