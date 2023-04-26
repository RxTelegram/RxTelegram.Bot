using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to add a new sticker to a set created by the bot.
    /// The format of the added sticker must match the format of the other stickers in the set.
    /// Emoji sticker sets can have up to 200 stickers.
    /// Animated and video sticker sets can have up to 50 stickers.
    /// Static sticker sets can have up to 120 stickers.
    /// Returns True on success.
    /// </summary>
    public class AddStickerToSet : BaseValidation
    {
        /// <summary>
        /// Required
        /// User identifier of sticker set owner
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Required
        /// Sticker set name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A JSON-serialized object with information about the added sticker.
        /// If exactly the same sticker had already been added to the set, then the set isn't changed.
        /// </summary>
        public InputSticker Sticker { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
