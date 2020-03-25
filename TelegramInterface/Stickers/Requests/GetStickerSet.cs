﻿namespace TelegramInterface.Stickers.Requests
{
    /// <summary>
    /// Use this method to get a sticker set. On success, a StickerSet object is returned.
    /// </summary>
    public class GetStickerSet
    {
        /// <summary>
        /// Name of the sticker set
        /// </summary>
        public string Name { get; set; }
    }
}