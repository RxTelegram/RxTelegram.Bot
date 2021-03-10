using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Stickers.Requests
{
    public class UploadStickerFile : BaseValidation
    {
        /// <summary>
        /// Required
        /// User identifier of sticker file owner
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Required
        /// Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height
        /// must be exactly 512px. More info on Sending Files »
        /// </summary>
        public InputFile PngSticker { get; set; }

        //ValidateCondition(UserId < 1, Bot.Validation.ValidationErrors.IdLowerThanOne, nameof(UserId));
        //ValidateRequired<UploadStickerFile>(x => x.UserId, x => x.PngSticker);
        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
