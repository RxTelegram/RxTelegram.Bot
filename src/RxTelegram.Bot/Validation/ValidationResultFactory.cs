using RxTelegram.Bot.Interface.Stickers.Requests;

namespace RxTelegram.Bot.Validation
{
    public static class ValidationResultFactory
    {
        public static ValidationResult<CreateNewStickerSet> CreateValidation(this CreateNewStickerSet value) =>
            new ValidationResult<CreateNewStickerSet>(value)
                .ValidateCondition(x => x.UserId < 1, ValidationErrors.IdLowerThanOne, nameof(CreateNewStickerSet.UserId))
                .ValidateCondition(x => x.PngSticker == null && x.TgsSticker == null, ValidationErrors.NonePropertySet,
                                   nameof(CreateNewStickerSet.PngSticker), nameof(CreateNewStickerSet.TgsSticker))
                .ValidateCondition(x => x.PngSticker != null && x.TgsSticker != null, ValidationErrors.OnlyONePropertyCanBeSet,
                                   nameof(CreateNewStickerSet.PngSticker), nameof(CreateNewStickerSet.TgsSticker))
                .ValidateRequired(x => x.UserId)
                .ValidateRequired(x => x.Name)
                .ValidateRequired(x => x.Title)
                .ValidateRequired(x => x.Emojis)
                .ValidateCondition(x => x.Name != null && x.Name.Contains("_by_"), ValidationErrors.InvalidStickerName,
                                   nameof(CreateNewStickerSet.Name));
    }
}
