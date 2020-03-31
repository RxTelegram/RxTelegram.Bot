using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to send static .WEBP or animated .TGS stickers. On success, the sent Message is returned.
    /// </summary>
    public class SendSticker : BaseValidation
    {
        /// <summary>
        /// Required
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// Required
        /// Sticker to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL
        /// as a String for Telegram to get a .WEBP file from the Internet, or upload a new one using multipart/form-data.
        /// </summary>
        public InputFile Sticker { get; set; }

        /// <summary>
        /// Optional
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool DisableNotification { get; set; }

        /// <summary>
        /// Optional
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove
        /// reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup ReplyMarkup { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
