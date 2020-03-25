﻿using TelegramInterface.BaseTypes.Requests.Attachments;

namespace TelegramInterface.Stickers.Requests
{
    public class UploadStickerFile
    {
        /// <summary>
        /// Required
        /// User identifier of sticker file owner
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Required
        /// Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height
        /// must be exactly 512px. More info on Sending Files »
        /// </summary>
        public InputFile PngSticker { get; set; }
    }
}
