using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
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

        public static ValidationResult<SendLocation> CreateValidation(this SendLocation value) =>
            new ValidationResult<SendLocation>(value)
                .ValidateRequired(x => x.ChatId)
                .ValidateRequired(x => x.Latitude)
                .ValidateRequired(x => x.Longitude);

        public static ValidationResult<EditMessageLiveLocation> CreateValidation(this EditMessageLiveLocation value) =>
            new ValidationResult<EditMessageLiveLocation>(value)
                .ValidateRequired(x => x.Latitude)
                .ValidateRequired(x => x.Longitude)
                .IsTrue(x => x.ChatId == null && x.MessageId == null && x.InlineMessageId == null,
                        ValidationErrors.InlineMessageIdChatIdMessageIdRequired);

        public static ValidationResult<GetChat> CreateValidation(this GetChat value) =>
            new ValidationResult<GetChat>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<GetChatMember> CreateValidation(this GetChatMember value) =>
            new ValidationResult<GetChatMember>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.UserId);

        public static ValidationResult<GetStickerSet> CreateValidation(this GetStickerSet value) =>
            new ValidationResult<GetStickerSet>(value).ValidateRequired(x => x.Name);

        public static ValidationResult<GetUserProfilePhotos> CreateValidation(this GetUserProfilePhotos value) =>
            new ValidationResult<GetUserProfilePhotos>(value).ValidateRequired(x => x.UserId);

        public static ValidationResult<GetChatAdministrators> CreateValidation(this GetChatAdministrators value) =>
            new ValidationResult<GetChatAdministrators>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<GetChatMembersCount> CreateValidation(this GetChatMembersCount value) =>
            new ValidationResult<GetChatMembersCount>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<KickChatMember> CreateValidation(this KickChatMember value) =>
            new ValidationResult<KickChatMember>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.UserId);

        public static ValidationResult<DeleteMessage> CreateValidation(this DeleteMessage value) =>
            new ValidationResult<DeleteMessage>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.MessageId);
    }
}
