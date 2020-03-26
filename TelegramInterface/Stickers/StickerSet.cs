using System.Collections.Generic;

namespace TelegramInterface.Stickers
{
    /// <summary>
    /// This object represents a sticker set.
    /// <see href="https://core.telegram.org/bots/api#stickerset"/>
    /// </summary>
    public class StickerSet
    {
        /// <summary>
        /// Sticker set name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sticker set title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// True, if the sticker set contains animated stickers
        /// </summary>
        public bool IsAnimated { get; set; }

        /// <summary>
        /// True, if the sticker set contains masks
        /// </summary>
        public bool ContainsMasks { get; set; }

        /// <summary>
        /// List of all set stickers
        /// </summary>
        public IEnumerable<Sticker> Stickers { get; set; }
    }
}
