namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to delete a sticker from a set created by the bot. Returns True on success.
    /// </summary>
    public class DeleteStickerFromSet
    {
        /// <summary>
        /// File identifier of the sticker
        /// </summary>
        public string Sticker { get; set; }
    }
}
