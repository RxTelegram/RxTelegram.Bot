using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to set the thumbnail of a sticker set. Animated thumbnails can be set for animated sticker sets only.
    /// Returns True on success.
    /// </summary>
    public class SetStickerSetThumb
    {
        /// <summary>
        /// Required
        /// Sticker set name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Required
        /// User identifier of the sticker set owner
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Optional
        /// A PNG image with the thumbnail, must be up to 128 kilobytes in size and have width and height exactly 100px, or a TGS animation
        /// with the thumbnail up to 32 kilobytes in size; see https://core.telegram.org/animated_stickers#technical-requirements for
        /// animated sticker technical requirements. Pass a file_id as a String to send a file that already exists on the Telegram servers,
        /// pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data.
        /// More info on Sending Files ». Animated sticker set thumbnail can't be uploaded via HTTP URL.
        /// </summary>
        public InputFile Thumb { get; set; }
    }
}
