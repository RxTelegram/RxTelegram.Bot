using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to add a new sticker to a set created by the bot. Returns True on success.
    /// </summary>
    public class AddStickerToSet
    {
        /// <summary>
        /// Required
        /// User identifier of sticker set owner
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Required
        /// Sticker set name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Required
        /// Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height
        /// must be exactly 512px. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL
        /// as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data.
        /// </summary>
        public InputFile PngSticker { get; set; }

        /// <summary>
        /// Required
        /// One or more emoji corresponding to the sticker
        /// </summary>
        public string Emojis { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for position where the mask should be placed on faces
        /// </summary>
        public MaskPosition MaskPosition { get; set; }
    }
}
