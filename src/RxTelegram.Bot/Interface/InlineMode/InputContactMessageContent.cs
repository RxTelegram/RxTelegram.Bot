using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.InlineMode
{
    /// <summary>
    /// Represents the content of a contact message to be sent as the result of an inline query.
    /// </summary>
    public class InputContactMessageContent : InputMessageContent
    {
        /// <summary>
        /// Contact's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contact's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Contact's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes
        /// </summary>
        public string Vcard { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
