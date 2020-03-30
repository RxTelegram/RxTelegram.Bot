using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to create new sticker set owned by a user. The bot will be able to edit the created sticker set.
    /// Returns True on success.
    /// </summary>
    public class CreateNewStickerSet
    {
        /// <summary>
        /// Required
        /// User identifier of created sticker set owner
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Required
        /// Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals). Can contain only english letters, digits and
        /// underscores. Must begin with a letter, can't contain consecutive underscores and must end in “_by_<bot username>”.
        /// <bot_username> is case insensitive. 1-64 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Required
        /// Sticker set title, 1-64 characters
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Required
        /// Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height
        /// must be exactly 512px. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL
        /// as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data.
        /// </summary>
        public InputFile TgsSticker { get; set; }

        /// <summary>
        /// Required
        /// One or more emoji corresponding to the sticker
        /// </summary>
        public string Emojis { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if a set of mask stickers should be created
        /// </summary>
        public bool ContainsMasks { get; set; }

        /// <summary>
        /// Optional
        /// A JSON-serialized object for position where the mask should be placed on faces
        /// </summary>
        public MaskPosition MaskPosition { get; set; }
    }
}
