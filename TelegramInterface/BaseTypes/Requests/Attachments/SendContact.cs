using TelegramInterface.BaseTypes.Requests.Base;
using TelegramInterface.BaseTypes.Requests.Base.Interfaces;

namespace TelegramInterface.BaseTypes.Requests.Attachments
{
    /// <summary>
    /// Use this method to send phone contacts. On success, the sent Message is returned.
    /// </summary>
    public class SendContact : BaseRequest
    {
        /// <summary>
        /// Required
        /// Contact's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Required
        /// Contact's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional
        /// Contact's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional
        /// Additional data about the contact in the form of a vCard, 0-2048 bytes
        /// </summary>
        public string Vcard { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup ReplyMarkup { get; set; }
    }
}
