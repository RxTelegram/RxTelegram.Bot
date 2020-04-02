using RxTelegram.Bot.Interface.Stickers.Requests;

namespace RxTelegram.Bot.Validation
{
    public static class ValidationResultFactory
    {
        public static ValidationResult<CreateNewStickerSet> CreateValidation(this CreateNewStickerSet value) =>
            new ValidationResult<CreateNewStickerSet>(value)
                .IsFalse(x => x.UserId < 1, ValidationErrors.IdLowerThanOne)
                .IsTrue(x => x.PngSticker == null && x.TgsSticker == null, ValidationErrors.NonePropertySet)
                .IsTrue(x => x.PngSticker != null && x.TgsSticker != null, ValidationErrors.OnlyONePropertyCanBeSet)
                .ValidateRequired(x => x.UserId)
                .ValidateRequired(x => x.Name)
                .ValidateRequired(x => x.Title)
                .ValidateRequired(x => x.Emojis)
                .IsFalse(x => x.Name != null && x.Name.Contains("_by_"), ValidationErrors.InvalidStickerName);
    }
}
