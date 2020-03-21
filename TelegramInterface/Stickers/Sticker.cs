﻿using TelegramInterface.BaseTypes;

namespace TelegramInterface.Stickers
{
    /// <summary>
    /// This object represents a sticker.
    /// <see href="https://core.telegram.org/bots/api#sticker"/>
    /// </summary>
    public class Sticker : FileBase
    {
	    /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
        /// </summary>
        public string FileUniqueId { get; set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// True, if the sticker is animated
        /// </summary>
        public bool IsAnimated { get; set; }

        /// <summary>
        /// Sticker thumbnail in .webp or .jpg format
        /// </summary>
        public PhotoSize Thumb { get; set; }

        /// <summary>
        /// Emoji associated with the sticker
        /// </summary>
        public string Emoji { get; set; }

        /// <summary>
        /// Optional. Name of the sticker set to which the sticker belongs
        /// </summary>
        public string SetName { get; set; }

        /// <summary>
        /// Optional. For mask stickers, the position where the mask should be placed
        /// </summary>
        public MaskPosition MaskPosition { get; set; }

        /// <summary>
        /// Optional. File size, if known
        /// </summary>
        public int FileSize { get; set; }
    }
}
