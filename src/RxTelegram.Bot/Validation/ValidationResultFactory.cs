using System.Linq;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
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
            new ValidationResult<CreateNewStickerSet>(value).IsTrue(x => x.UserId < 1, ValidationErrors.IdLowerThanOne)
                                                            .IsTrue(x => x.PngSticker == null && x.TgsSticker == null,
                                                                    ValidationErrors.NonePropertySet)
                                                            .IsTrue(x => x.PngSticker != null && x.TgsSticker != null,
                                                                    ValidationErrors.OnlyONePropertyCanBeSet)
                                                            .ValidateRequired(x => x.UserId)
                                                            .ValidateRequired(x => x.Name)
                                                            .ValidateRequired(x => x.Title)
                                                            .ValidateRequired(x => x.Emojis)
                                                            .IsFalse(x => x.Name != null && x.Name.Contains("_by_"),
                                                                     ValidationErrors.InvalidStickerName);

        public static ValidationResult<SendLocation> CreateValidation(this SendLocation value) => new ValidationResult<SendLocation>(value)
                                                                                                  .ValidateRequired(x => x.ChatId)
                                                                                                  .ValidateRequired(x => x.Latitude)
                                                                                                  .ValidateRequired(x => x.Longitude);

        public static ValidationResult<EditMessageLiveLocation> CreateValidation(this EditMessageLiveLocation value) =>
            new ValidationResult<EditMessageLiveLocation>(value).ValidateRequired(x => x.Latitude)
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

        public static ValidationResult<SendMessage> CreateValidation(this SendMessage value) => new ValidationResult<SendMessage>(value)
                                                                                                .ValidateRequired(x => x.ChatId)
                                                                                                .ValidateRequired(x => x.Text);

        public static ValidationResult<ForwardMessage> CreateValidation(this ForwardMessage value) =>
            new ValidationResult<ForwardMessage>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.FromChatId)
                                                       .ValidateRequired(x => x.MessageId);

        public static ValidationResult<SendPhoto> CreateValidation(this SendPhoto value) => new ValidationResult<SendPhoto>(value)
                                                                                            .ValidateRequired(x => x.ChatId)
                                                                                            .ValidateRequired(x => x.Photo);

        public static ValidationResult<SendAudio> CreateValidation(this SendAudio value) => new ValidationResult<SendAudio>(value)
                                                                                            .ValidateRequired(x => x.ChatId)
                                                                                            .ValidateRequired(x => x.Audio);

        public static ValidationResult<SendDocument> CreateValidation(this SendDocument value) => new ValidationResult<SendDocument>(value)
                                                                                                  .ValidateRequired(x => x.ChatId)
                                                                                                  .ValidateRequired(x => x.Document);

        public static ValidationResult<SendVideo> CreateValidation(this SendVideo value) => new ValidationResult<SendVideo>(value)
                                                                                            .ValidateRequired(x => x.ChatId)
                                                                                            .ValidateRequired(x => x.Video);

        public static ValidationResult<SendAnimation> CreateValidation(this SendAnimation value) =>
            new ValidationResult<SendAnimation>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.Animation);

        public static ValidationResult<SendVoice> CreateValidation(this SendVoice value) => new ValidationResult<SendVoice>(value)
                                                                                            .ValidateRequired(x => x.ChatId)
                                                                                            .ValidateRequired(x => x.Voice);

        public static ValidationResult<GetChatMembersCount> CreateValidation(this GetChatMembersCount value) =>
            new ValidationResult<GetChatMembersCount>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<SendVideoNote> CreateValidation(this SendVideoNote value) =>
            new ValidationResult<SendVideoNote>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.VideoNote);

        public static ValidationResult<SendMediaGroup> CreateValidation(this SendMediaGroup value) =>
            new ValidationResult<SendMediaGroup>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.Media)
                                                       .IsFalse(x => x.Media != null &&
                                                                     x.Media.All(input =>
                                                                                     input.GetType() == typeof(InputMediaPhoto)
                                                                                     || input.GetType() == typeof(InputMediaVideo)),
                                                                ValidationErrors.OnlyInputMediaPhotoOrInputMediaVideo);

        public static ValidationResult<KickChatMember> CreateValidation(this KickChatMember value) =>
            new ValidationResult<KickChatMember>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.UserId);

        public static ValidationResult<DeleteMessage> CreateValidation(this DeleteMessage value) =>
            new ValidationResult<DeleteMessage>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.MessageId);

        public static ValidationResult<DeleteChatPhoto> CreateValidation(this DeleteChatPhoto value) =>
            new ValidationResult<DeleteChatPhoto>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<LeaveChat> CreateValidation(this LeaveChat value) =>
            new ValidationResult<LeaveChat>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<AddStickerToSet> CreateValidation(this AddStickerToSet value) =>
            new ValidationResult<AddStickerToSet>(value).ValidateRequired(x => x.UserId)
                                                        .ValidateRequired(x => x.Name)
                                                        .ValidateRequired(x => x.Emojis)
                                                        .IsTrue(x => x.PngSticker == null && x.TgsSticker == null,
                                                                ValidationErrors.NonePropertySet)
                                                        .IsTrue(x => x.PngSticker != null && x.TgsSticker != null,
                                                                ValidationErrors.OnlyONePropertyCanBeSet);

        public static ValidationResult<DeleteStickerFromSet> CreateValidation(this DeleteStickerFromSet value) =>
            new ValidationResult<DeleteStickerFromSet>(value).ValidateRequired(x => x.Sticker);

        public static ValidationResult<PinChatMessage> CreateValidation(this PinChatMessage value) =>
            new ValidationResult<PinChatMessage>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.MessageId);

        public static ValidationResult<UnpinChatMessage> CreateValidation(this UnpinChatMessage value) =>
            new ValidationResult<UnpinChatMessage>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<SetChatDescription> CreateValidation(this SetChatDescription value) =>
            new ValidationResult<SetChatDescription>(value).ValidateRequired(x => x.ChatId)
                                                           .ValidateRequired(x => x.Description);

        public static ValidationResult<SetChatPermissions> CreateValidation(this SetChatPermissions value) =>
            new ValidationResult<SetChatPermissions>(value).ValidateRequired(x => x.ChatId)
                                                           .ValidateRequired(x => x.Permissions);

        public static ValidationResult<SetChatTitle> CreateValidation(this SetChatTitle value) =>
            new ValidationResult<SetChatTitle>(value).ValidateRequired(x => x.ChatId)
                                                     .ValidateRequired(x => x.Title);

        public static ValidationResult<SetChatStickerSet> CreateValidation(this SetChatStickerSet value) =>
            new ValidationResult<SetChatStickerSet>(value).ValidateRequired(x => x.ChatId)
                                                          .ValidateRequired(x => x.StickerSetName);

        public static ValidationResult<SendSticker> CreateValidation(this SendSticker value) =>
            new ValidationResult<SendSticker>(value).ValidateRequired(x => x.ChatId)
                                                    .ValidateRequired(x => x.Sticker);

        public static ValidationResult<SetChatPhoto> CreateValidation(this SetChatPhoto value) =>
            new ValidationResult<SetChatPhoto>(value).ValidateRequired(x => x.ChatId)
                                                     .ValidateRequired(x => x.Photo);
    }
}
