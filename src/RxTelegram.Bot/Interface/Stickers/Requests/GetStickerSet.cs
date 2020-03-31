using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    /// <summary>
    /// Use this method to get a sticker set. On success, a StickerSet object is returned.
    /// </summary>
    public class GetStickerSet : BaseValidation
    {
        /// <summary>
        /// Name of the sticker set
        /// </summary>
        public string Name { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
