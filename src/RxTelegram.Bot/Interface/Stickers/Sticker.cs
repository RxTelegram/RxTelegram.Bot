using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Stickers.Enums;

namespace RxTelegram.Bot.Interface.Stickers
{
    /// <summary>
    /// This object represents a sticker.
    /// <see href="https://core.telegram.org/bots/api#sticker"/>
    /// </summary>
    public class Sticker : FileBase
    {
        /// <summary>
        /// Type of the sticker, currently one of “regular”, “mask”, “custom_emoji”.
        /// The type of the sticker is independent from its format,
        /// which is determined by the fields is_animated and is_video.
        /// </summary>
        public StickerType Type { get; set; }

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
        /// True, if the sticker is a video sticker
        /// </summary>
        public bool IsVideo { get; set; }

        /// <summary>
        /// Sticker thumbnail in .webp or .jpg format
        /// </summary>
        public PhotoSize Thumbnail { get; set; }

        /// <summary>
        /// Emoji associated with the sticker
        /// </summary>
        public string Emoji { get; set; }

        /// <summary>
        /// Optional. Name of the sticker set to which the sticker belongs
        /// </summary>
        public string SetName { get; set; }

        /// <summary>
        /// Optional. Premium animation for the sticker, if the sticker is premium
        /// </summary>
        public File PremiumAnimation { get; set; }

        /// <summary>
        /// Optional. For mask stickers, the position where the mask should be placed
        /// </summary>
        public MaskPosition MaskPosition { get; set; }

        /// <summary>
        /// Optional. For custom emoji stickers, unique identifier of the custom emoji
        /// </summary>
        public string CustomEmojiId { get; set; }

        /// <summary>
        /// Optional. True, if the sticker must be repainted to a text color in messages, the color of the Telegram Premium
        /// badge in emoji status, white color on chat photos, or another appropriate color in other places
        /// </summary>
        public bool? NeedsRepainting { get; set; }
    }
}
