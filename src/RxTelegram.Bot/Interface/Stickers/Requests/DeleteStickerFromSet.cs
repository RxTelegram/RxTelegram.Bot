using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to delete a sticker from a set created by the bot. Returns True on success.
    /// </summary>
    public class DeleteStickerFromSet : BaseValidation
    {
        /// <summary>
        /// File identifier of the sticker
        /// </summary>
        public string Sticker { get; set; }

        protected override IValidationResult Validate() => throw new System.NotImplementedException();
    }
}
