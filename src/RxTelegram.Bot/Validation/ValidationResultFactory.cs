using System;
using System.Linq;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Callbacks;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
using RxTelegram.Bot.Interface.Games.Requests;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;
using RxTelegram.Bot.Interface.Passport.Requests;
using RxTelegram.Bot.Interface.Payments.Requests;
using RxTelegram.Bot.Interface.Setup;
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
                                                                    ValidationErrors.OnlyOnePropertyCanBeSet)
                                                            .ValidateRequired(x => x.UserId)
                                                            .ValidateRequired(x => x.Name)
                                                            .ValidateRequired(x => x.Title)
                                                            .ValidateRequired(x => x.Emojis)
                                                            .IsFalse(x => x.Name != null && x.Name.Contains("_by_"),
                                                                     ValidationErrors.InvalidStickerName);

        public static ValidationResult<SendLocation> CreateValidation(this SendLocation value) => new ValidationResult<SendLocation>(value)
            .ValidateRequired(x => x.ChatId)
            .ValidateRequired(x => x.Latitude)
            .ValidateRequired(x => x.Longitude)
            .IsFalse(x => x.Heading != null && x.Heading < 1 && x.Heading > 360, ValidationErrors.HeadingOutOfRange)
            .IsFalse(x => x.ProximityAlertRadius != null && x.ProximityAlertRadius < 1 && x.ProximityAlertRadius > 100000,
                     ValidationErrors.ProximityAlertRadiusOutOfRange)
            .IsFalse(x => x.HorizontalAccuracy != null && x.ProximityAlertRadius < 0 && x.ProximityAlertRadius > 1500,
                     ValidationErrors.HorizontalAccuracyOutOfRange);

        public static ValidationResult<EditMessageLiveLocation> CreateValidation(this EditMessageLiveLocation value) =>
            new ValidationResult<EditMessageLiveLocation>(value).ValidateRequired(x => x.Latitude)
                                                                .ValidateRequired(x => x.Longitude)
                                                                .IsTrue(x => x.ChatId == null && x.MessageId == null && x.InlineMessageId == null,
                                                                        ValidationErrors.InlineMessageIdChatIdMessageIdRequiredOr)
                                                                .IsFalse(x => x.Heading != null && x.Heading < 1 && x.Heading > 360, ValidationErrors.HeadingOutOfRange)
                                                                .IsFalse(x => x.ProximityAlertRadius != null && x.ProximityAlertRadius < 1 && x.ProximityAlertRadius > 100000,
                                                                         ValidationErrors.ProximityAlertRadiusOutOfRange)
                                                                .IsFalse(x => x.HorizontalAccuracy != null && x.ProximityAlertRadius < 0 && x.ProximityAlertRadius > 1500,
                                                                         ValidationErrors.HorizontalAccuracyOutOfRange);

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

        public static ValidationResult<GetChatMemberCount> CreateValidation(this GetChatMemberCount value) =>
            new ValidationResult<GetChatMemberCount>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<SendVideoNote> CreateValidation(this SendVideoNote value) =>
            new ValidationResult<SendVideoNote>(value).ValidateRequired(x => x.ChatId)
                                                      .ValidateRequired(x => x.VideoNote);

        public static ValidationResult<SendMediaGroup> CreateValidation(this SendMediaGroup value) =>
            new ValidationResult<SendMediaGroup>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.Media)
                                                       .IsFalse(x => x.Media != null
                                                                     && x.Media.All(input =>
                                                                                        input.GetType() == typeof(InputMediaPhoto) ||
                                                                                        input.GetType() == typeof(InputMediaDocument) ||
                                                                                        input.GetType() == typeof(InputMediaAudio) ||
                                                                                        input.GetType() == typeof(InputMediaVideo)),
                                                                ValidationErrors.OnlySomeInputMediaTypesAllowed);

        public static ValidationResult<BanChatMember> CreateValidation(this BanChatMember value) =>
            new ValidationResult<BanChatMember>(value).ValidateRequired(x => x.ChatId)
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
                                                                ValidationErrors.OnlyOnePropertyCanBeSet);

        public static ValidationResult<DeleteStickerFromSet> CreateValidation(this DeleteStickerFromSet value) =>
            new ValidationResult<DeleteStickerFromSet>(value).ValidateRequired(x => x.Sticker);

        public static ValidationResult<PinChatMessage> CreateValidation(this PinChatMessage value) =>
            new ValidationResult<PinChatMessage>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.MessageId);

        public static ValidationResult<UnpinChatMessage> CreateValidation(this UnpinChatMessage value) =>
            new ValidationResult<UnpinChatMessage>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<UnpinAllChatMessages> CreateValidation(this UnpinAllChatMessages value) =>
            new ValidationResult<UnpinAllChatMessages>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<SetChatDescription> CreateValidation(this SetChatDescription value) =>
            new ValidationResult<SetChatDescription>(value).ValidateRequired(x => x.ChatId)
                                                           .ValidateRequired(x => x.Description);

        public static ValidationResult<SetChatPermissions> CreateValidation(this SetChatPermissions value) =>
            new ValidationResult<SetChatPermissions>(value).ValidateRequired(x => x.ChatId)
                                                           .ValidateRequired(x => x.Permissions);

        public static ValidationResult<SetChatTitle> CreateValidation(this SetChatTitle value) => new ValidationResult<SetChatTitle>(value)
                                                                                                  .ValidateRequired(x => x.ChatId)
                                                                                                  .ValidateRequired(x => x.Title);

        public static ValidationResult<SetChatStickerSet> CreateValidation(this SetChatStickerSet value) =>
            new ValidationResult<SetChatStickerSet>(value).ValidateRequired(x => x.ChatId)
                                                          .ValidateRequired(x => x.StickerSetName);

        public static ValidationResult<SendSticker> CreateValidation(this SendSticker value) => new ValidationResult<SendSticker>(value)
                                                                                                .ValidateRequired(x => x.ChatId)
                                                                                                .ValidateRequired(x => x.Sticker);

        public static ValidationResult<SetChatPhoto> CreateValidation(this SetChatPhoto value) => new ValidationResult<SetChatPhoto>(value)
                                                                                                  .ValidateRequired(x => x.ChatId)
                                                                                                  .ValidateRequired(x => x.Photo);

        public static ValidationResult<ExportChatInviteLink> CreateValidation(this ExportChatInviteLink value) =>
            new ValidationResult<ExportChatInviteLink>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<PromoteChatMember> CreateValidation(this PromoteChatMember value) =>
            new ValidationResult<PromoteChatMember>(value).ValidateRequired(x => x.ChatId)
                                                          .ValidateRequired(x => x.UserId);

        public static ValidationResult<RestrictChatMember> CreateValidation(this RestrictChatMember value) =>
            new ValidationResult<RestrictChatMember>(value).ValidateRequired(x => x.Permissions)
                                                           .ValidateRequired(x => x.UserId)
                                                           .ValidateRequired(x => x.ChatId);

        public static ValidationResult<SendContact> CreateValidation(this SendContact value) => new ValidationResult<SendContact>(value)
                                                                                                .ValidateRequired(x => x.FirstName)
                                                                                                .ValidateRequired(x => x.PhoneNumber)
                                                                                                .ValidateRequired(x => x.ChatId);

        public static ValidationResult<UploadStickerFile> CreateValidation(this UploadStickerFile value) =>
            new ValidationResult<UploadStickerFile>(value).ValidateRequired(x => x.UserId)
                                                          .ValidateRequired(x => x.PngSticker);

        public static ValidationResult<EditMessageText> CreateValidation(this EditMessageText value) =>
            new ValidationResult<EditMessageText>(value)
                .IsTrue(x => (x.ChatId == null || !x.ChatId.HasValue) && x.MessageId == null && string.IsNullOrEmpty(x.InlineMessageId),
                        ValidationErrors.InlineMessageIdChatIdMessageIdRequiredOr)
                .IsTrue(x => x.ChatId != null && x.ChatId.HasValue && x.MessageId != null && !string.IsNullOrEmpty(x.InlineMessageId),
                        ValidationErrors.InlineMessageIdOrChatIdAndMessageId)
                .IsTrue(x => (x.ChatId == null || !x.ChatId.HasValue) && x.MessageId != null && !string.IsNullOrEmpty(x.InlineMessageId),
                        ValidationErrors.InlineMessageIdOrChatIdAndMessageId)
                .IsTrue(x => x.ChatId != null && x.ChatId.HasValue && x.MessageId == null && !string.IsNullOrEmpty(x.InlineMessageId),
                        ValidationErrors.InlineMessageIdOrChatIdAndMessageId)
                // todo ValidationErrorsExtension needs to decide if its a PropertyExpression and TypedParameterExpression because
                // the erroring Property would always be Length instead of Text
                .IsTrue(x => x.Text != null && x.Text.Length > 4096, ValidationErrors.TextTooLong);

        public static ValidationResult<SetStickerPositionInSet> CreateValidation(this SetStickerPositionInSet value) =>
            new ValidationResult<SetStickerPositionInSet>(value).ValidateRequired(x => x.Position)
                                                                .ValidateRequired(x => x.Sticker);

        public static ValidationResult<SendChatAction> CreateValidation(this SendChatAction value) =>
            new ValidationResult<SendChatAction>(value).ValidateRequired(x => x.ChatId)
                                                       .ValidateRequired(x => x.Action);

        public static ValidationResult<SendPoll> CreateValidation(this SendPoll value) => new ValidationResult<SendPoll>(value)
                                                                                          .ValidateRequired(x => x.ChatId)
                                                                                          .ValidateRequired(x => x.Question)
                                                                                          .ValidateRequired(x => x.Options)
                                                                                          .IsFalse(x => x.Question != null && x.Question.Length > 0 && x.Question.Length < 256,
                                                                                                   ValidationErrors.QuestionTooLong)
                                                                                          .IsFalse(x => x.Options != null && x.Options.Count() > 1 && x.Options.Count() <= 10,
                                                                                                   ValidationErrors.InvalidOptionCount)
                                                                                          .IsFalse(x => x.Options != null && x.Options.All(y => y.Length > 0 && y.Length <= 100),
                                                                                                   ValidationErrors.OptionStringTooLong)
                                                                                          .IsTrue(x => x.Type == PollType.Quiz && x.CorrectOptionId == null,
                                                                                                  ValidationErrors.CorrectOptionRequired)
                                                                                          .IsTrue(x => x.OpenPeriod.HasValue && x.CloseDate.HasValue,
                                                                                                   ValidationErrors
                                                                                                       .OnlyOnePropertyCanBeSet);

        public static ValidationResult<StopPoll> CreateValidation(this StopPoll value) =>
            new ValidationResult<StopPoll>(value).ValidateRequired(x => x.MessageId);

        public static ValidationResult<SetChatAdministratorCustomTitle> CreateValidation(this SetChatAdministratorCustomTitle value) =>
            new ValidationResult<SetChatAdministratorCustomTitle>(value).ValidateRequired(x => x.CustomTitle)
                                                                        .ValidateRequired(x => x.UserId)
                                                                        .ValidateRequired(x => x.ChatId);

        public static ValidationResult<UnbanChatMember> CreateValidation(this UnbanChatMember value) =>
            new ValidationResult<UnbanChatMember>(value).ValidateRequired(x => x.UserId);

        public static ValidationResult<SendGame> CreateValidation(this SendGame value) => new ValidationResult<SendGame>(value)
                                                                                          .ValidateRequired(x => x.GameShortName)
                                                                                          .ValidateRequired(x => x.ChatId);

        public static ValidationResult<SetGameScore> CreateValidation(this SetGameScore value) => new ValidationResult<SetGameScore>(value)
                                                                                                  .ValidateRequired(x => x.UserId)
                                                                                                  .ValidateRequired(x => x.Score);

        public static ValidationResult<GetGameHighScores> CreateValidation(this GetGameHighScores value) =>
            new ValidationResult<GetGameHighScores>(value).ValidateRequired(x => x.UserId)
                                                          .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.ChatId == null,
                                                                  ValidationErrors.FieldRequired)
                                                          .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.MessageId == null,
                                                                  ValidationErrors.FieldRequired);

        public static ValidationResult<StopMessageLiveLocation> CreateValidation(this StopMessageLiveLocation value) =>
            new ValidationResult<StopMessageLiveLocation>(value).IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.ChatId == null,
                                                                        ValidationErrors.FieldRequired)
                                                                .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.MessageId == null,
                                                                        ValidationErrors.FieldRequired);

        public static ValidationResult<EditMessageCaption> CreateValidation(this EditMessageCaption value) =>
            new ValidationResult<EditMessageCaption>(value).IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.ChatId == null,
                                                                   ValidationErrors.FieldRequired)
                                                           .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.MessageId == null,
                                                                   ValidationErrors.FieldRequired);

        public static ValidationResult<EditMessageReplyMarkup> CreateValidation(this EditMessageReplyMarkup value) =>
            new ValidationResult<EditMessageReplyMarkup>(value).IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.ChatId == null,
                                                                       ValidationErrors.FieldRequired)
                                                               .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.MessageId == null,
                                                                       ValidationErrors.FieldRequired);

        public static ValidationResult<AnswerCallbackQuery> CreateValidation(this AnswerCallbackQuery value) =>
            new ValidationResult<AnswerCallbackQuery>(value).ValidateRequired(x => x.CallbackQueryId);

        public static ValidationResult<AnswerInlineQuery> CreateValidation(this AnswerInlineQuery value) =>
            new ValidationResult<AnswerInlineQuery>(value).ValidateRequired(x => x.Results)
                                                          .ValidateRequired(x => x.InlineQueryId);

        public static ValidationResult<InlineQueryResultArticle> CreateValidation(this InlineQueryResultArticle value) =>
            new ValidationResult<InlineQueryResultArticle>(value).ValidateRequired(x => x.Type)
                                                                 .ValidateRequired(x => x.Id)
                                                                 .ValidateRequired(x => x.Title)
                                                                 .ValidateRequired(x => x.InputMessageContent);

        public static ValidationResult<InlineQueryResultPhoto> CreateValidation(this InlineQueryResultPhoto value) =>
            new ValidationResult<InlineQueryResultPhoto>(value).ValidateRequired(x => x.Type)
                                                               .ValidateRequired(x => x.Id)
                                                               .ValidateRequired(x => x.PhotoUrl)
                                                               .ValidateRequired(x => x.ThumbUrl);

        public static ValidationResult<InlineQueryResultGif> CreateValidation(this InlineQueryResultGif value) =>
            new ValidationResult<InlineQueryResultGif>(value).ValidateRequired(x => x.Type)
                                                             .ValidateRequired(x => x.Id)
                                                             .ValidateRequired(x => x.GifUrl)
                                                             .ValidateRequired(x => x.ThumbUrl);

        public static ValidationResult<InlineQueryResultMpeg4Gif> CreateValidation(this InlineQueryResultMpeg4Gif value) =>
            new ValidationResult<InlineQueryResultMpeg4Gif>(value).ValidateRequired(x => x.Type)
                                                                  .ValidateRequired(x => x.Id)
                                                                  .ValidateRequired(x => x.Mpeg4Url)
                                                                  .ValidateRequired(x => x.ThumbUrl);

        public static ValidationResult<InlineQueryResultVideo> CreateValidation(this InlineQueryResultVideo value) =>
            new ValidationResult<InlineQueryResultVideo>(value).ValidateRequired(x => x.Type)
                                                               .ValidateRequired(x => x.Id)
                                                               .ValidateRequired(x => x.VideoUrl)
                                                               .ValidateRequired(x => x.MimeType)
                                                               .ValidateRequired(x => x.Title)
                                                               .ValidateRequired(x => x.ThumbUrl);

        public static ValidationResult<InlineQueryResultAudio> CreateValidation(this InlineQueryResultAudio value) =>
            new ValidationResult<InlineQueryResultAudio>(value).ValidateRequired(x => x.Type)
                                                               .ValidateRequired(x => x.Id)
                                                               .ValidateRequired(x => x.AudioUrl)
                                                               .ValidateRequired(x => x.Title);

        public static ValidationResult<InlineQueryResultVoice> CreateValidation(this InlineQueryResultVoice value) =>
            new ValidationResult<InlineQueryResultVoice>(value).ValidateRequired(x => x.Type)
                                                               .ValidateRequired(x => x.Id)
                                                               .ValidateRequired(x => x.VoiceUrl)
                                                               .ValidateRequired(x => x.Title);

        public static ValidationResult<InlineQueryResultDocument> CreateValidation(this InlineQueryResultDocument value) =>
            new ValidationResult<InlineQueryResultDocument>(value).ValidateRequired(x => x.Type)
                                                                  .ValidateRequired(x => x.Id)
                                                                  .ValidateRequired(x => x.DocumentUrl)
                                                                  .ValidateRequired(x => x.MimeType)
                                                                  .ValidateRequired(x => x.Title);

        public static ValidationResult<InlineQueryResultLocation> CreateValidation(this InlineQueryResultLocation value) =>
            new ValidationResult<InlineQueryResultLocation>(value).ValidateRequired(x => x.Type)
                                                                  .ValidateRequired(x => x.Id)
                                                                  .ValidateRequired(x => x.Latitude)
                                                                  .ValidateRequired(x => x.Longitude)
                                                                  .ValidateRequired(x => x.Title);

        public static ValidationResult<InlineQueryResultVenue> CreateValidation(this InlineQueryResultVenue value) =>
            new ValidationResult<InlineQueryResultVenue>(value).ValidateRequired(x => x.Type)
                                                               .ValidateRequired(x => x.Id)
                                                               .ValidateRequired(x => x.Latitude)
                                                               .ValidateRequired(x => x.Longitude)
                                                               .ValidateRequired(x => x.Title)
                                                               .ValidateRequired(x => x.Address);

        public static ValidationResult<InlineQueryResultContact> CreateValidation(this InlineQueryResultContact value) =>
            new ValidationResult<InlineQueryResultContact>(value).ValidateRequired(x => x.Type)
                                                                 .ValidateRequired(x => x.Id)
                                                                 .ValidateRequired(x => x.PhoneNumber)
                                                                 .ValidateRequired(x => x.FirstName);

        public static ValidationResult<InlineQueryResultGame> CreateValidation(this InlineQueryResultGame value) =>
            new ValidationResult<InlineQueryResultGame>(value).ValidateRequired(x => x.Type)
                                                              .ValidateRequired(x => x.Id)
                                                              .ValidateRequired(x => x.GameShortName);

        public static ValidationResult<InlineQueryResultCachedPhoto> CreateValidation(this InlineQueryResultCachedPhoto value) =>
            new ValidationResult<InlineQueryResultCachedPhoto>(value).ValidateRequired(x => x.Type)
                                                                     .ValidateRequired(x => x.Id)
                                                                     .ValidateRequired(x => x.PhotoFileId);

        public static ValidationResult<InlineQueryResultCachedGif> CreateValidation(this InlineQueryResultCachedGif value) =>
            new ValidationResult<InlineQueryResultCachedGif>(value).ValidateRequired(x => x.Type)
                                                                   .ValidateRequired(x => x.Id)
                                                                   .ValidateRequired(x => x.GifFileId);

        public static ValidationResult<InlineQueryResultCachedMpeg4Gif> CreateValidation(this InlineQueryResultCachedMpeg4Gif value) =>
            new ValidationResult<InlineQueryResultCachedMpeg4Gif>(value).ValidateRequired(x => x.Type)
                                                                        .ValidateRequired(x => x.Id)
                                                                        .ValidateRequired(x => x.Mpeg4FileId);

        public static ValidationResult<InlineQueryResultCachedSticker> CreateValidation(this InlineQueryResultCachedSticker value) =>
            new ValidationResult<InlineQueryResultCachedSticker>(value).ValidateRequired(x => x.Type)
                                                                       .ValidateRequired(x => x.Id)
                                                                       .ValidateRequired(x => x.StickerFileId);

        public static ValidationResult<InlineQueryResultCachedDocument> CreateValidation(this InlineQueryResultCachedDocument value) =>
            new ValidationResult<InlineQueryResultCachedDocument>(value).ValidateRequired(x => x.Type)
                                                                        .ValidateRequired(x => x.Id)
                                                                        .ValidateRequired(x => x.Title)
                                                                        .ValidateRequired(x => x.DocumentFileId);

        public static ValidationResult<InlineQueryResultCachedVideo> CreateValidation(this InlineQueryResultCachedVideo value) =>
            new ValidationResult<InlineQueryResultCachedVideo>(value).ValidateRequired(x => x.Type)
                                                                     .ValidateRequired(x => x.Id)
                                                                     .ValidateRequired(x => x.Title)
                                                                     .ValidateRequired(x => x.VideoFileId);

        public static ValidationResult<InlineQueryResultCachedAudio> CreateValidation(this InlineQueryResultCachedAudio value) =>
            new ValidationResult<InlineQueryResultCachedAudio>(value).ValidateRequired(x => x.Type)
                                                                     .ValidateRequired(x => x.Id)
                                                                     .ValidateRequired(x => x.AudioFileId);
        public static ValidationResult<InlineQueryResultCachedVoice> CreateValidation(this InlineQueryResultCachedVoice value) =>
            new ValidationResult<InlineQueryResultCachedVoice>(value).ValidateRequired(x => x.Type)
                                                                     .ValidateRequired(x => x.Id)
                                                                     .ValidateRequired(x => x.VoiceFileId);


        public static ValidationResult<InputTextMessageContent> CreateValidation(this InputTextMessageContent value) =>
            new ValidationResult<InputTextMessageContent>(value).ValidateRequired(x => x.MessageText);

        public static ValidationResult<InputLocationMessageContent> CreateValidation(this InputLocationMessageContent value) =>
            new ValidationResult<InputLocationMessageContent>(value).ValidateRequired(x => x.Latitude)
                                                                    .ValidateRequired(x => x.Longitude);

        public static ValidationResult<InputVenueMessageContent> CreateValidation(this InputVenueMessageContent value) =>
            new ValidationResult<InputVenueMessageContent>(value).ValidateRequired(x => x.Latitude)
                                                                 .ValidateRequired(x => x.Longitude)
                                                                 .ValidateRequired(x => x.Title)
                                                                 .ValidateRequired(x => x.Address);

        public static ValidationResult<InputContactMessageContent> CreateValidation(this InputContactMessageContent value) =>
            new ValidationResult<InputContactMessageContent>(value).ValidateRequired(x => x.PhoneNumber)
                                                                   .ValidateRequired(x => x.FirstName);

        public static ValidationResult<SetMyCommands> CreateValidation(this SetMyCommands value) =>
            new ValidationResult<SetMyCommands>(value).ValidateRequired(x => x.Commands)
                                                      .IsTrue(x => x.Commands != null && x.Commands.Count() > 100,
                                                              ValidationErrors.CommandLimit);

        public static ValidationResult<SendVenue> CreateValidation(this SendVenue value) =>
            new ValidationResult<SendVenue>(value).ValidateRequired(x => x.ChatId)
                                                  .ValidateRequired(x => x.Latitude)
                                                  .ValidateRequired(x => x.Title)
                                                  .ValidateRequired(x => x.Address)
                                                  .ValidateRequired(x => x.Longitude);

        public static ValidationResult<SetWebhook> CreateValidation(this SetWebhook value)
        {
            Uri uri = null;
            return new ValidationResult<SetWebhook>(value).ValidateRequired(x => x.Url)
                                                          .IsFalse(x => Uri.TryCreate(x.Url, UriKind.Absolute, out uri),
                                                                   ValidationErrors.UrlInvalid)
                                                          .IsFalse(x => uri == null || new[] {443, 80, 88, 8443}.Contains(new Uri(x.Url).Port),
                                                                   ValidationErrors.SupportedPortsWebhook);
        }

        public static ValidationResult<DeleteChatStickerSet> CreateValidation(this DeleteChatStickerSet value) =>
            new ValidationResult<DeleteChatStickerSet>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<SendInvoice> CreateValidation(this SendInvoice value) => new ValidationResult<SendInvoice>(value)
                                                                                                .ValidateRequired(x => x.ChatId)
                                                                                                .ValidateRequired(x => x.Title)
                                                                                                .ValidateRequired(x => x.Payload)
                                                                                                .ValidateRequired(x => x.ProviderToken)
                                                                                                .ValidateRequired(x => x.Currency)
                                                                                                .ValidateRequired(x => x.Prices)
                                                                                                .ValidateRequired(x => x.Description);

        public static ValidationResult<AnswerShippingQuery> CreateValidation(this AnswerShippingQuery value) =>
            new ValidationResult<AnswerShippingQuery>(value).ValidateRequired(x => x.ShippingQueryId)
                                                            .ValidateRequired(x => x.Ok);

        public static ValidationResult<AnswerPreCheckoutQuery> CreateValidation(this AnswerPreCheckoutQuery value) =>
            new ValidationResult<AnswerPreCheckoutQuery>(value).ValidateRequired(x => x.PreCheckoutQueryId)
                                                               .ValidateRequired(x => x.Ok);

        public static ValidationResult<SetPassportDataErrors> CreateValidation(this SetPassportDataErrors value) =>
            new ValidationResult<SetPassportDataErrors>(value).ValidateRequired(x => x.Type)
                                                              .ValidateRequired(x => x.UserId);

        public static ValidationResult<EditMessageMedia> CreateValidation(this EditMessageMedia value) =>
            new ValidationResult<EditMessageMedia>(value).ValidateRequired(x => x.Media)
                                                         .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.ChatId == null,
                                                                 ValidationErrors.FieldRequired)
                                                         .IsTrue(x => string.IsNullOrEmpty(x.InlineMessageId) && x.MessageId == null,
                                                                 ValidationErrors.FieldRequired);

        public static ValidationResult<SetStickerSetThumb> CreateValidation(this SetStickerSetThumb value) =>
            new ValidationResult<SetStickerSetThumb>(value).ValidateRequired(x => x.Name)
                                                           .ValidateRequired(x => x.UserId);

        public static ValidationResult<SendDice> CreateValidation(this SendDice value) =>
            new ValidationResult<SendDice>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<CopyMessage> CreateValidation(this CopyMessage value) => new ValidationResult<CopyMessage>(value)
            .ValidateRequired(x => x.ChatId)
            .ValidateRequired(x => x.FromChatId)
            .ValidateRequired(x => x.MessageId);

        public static ValidationResult<CreateChatInviteLink> CreateValidation(this CreateChatInviteLink value) =>
            new ValidationResult<CreateChatInviteLink>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<EditChatInviteLink> CreateValidation(this EditChatInviteLink value) =>
            new ValidationResult<EditChatInviteLink>(value).ValidateRequired(x => x.ChatId)
                                                           .ValidateRequired(x => x.InviteLink);

        public static ValidationResult<RevokeChatInviteLink> CreateValidation(this RevokeChatInviteLink value) =>
            new ValidationResult<RevokeChatInviteLink>(value).ValidateRequired(x => x.ChatId);

        public static ValidationResult<ApproveChatJoinRequest> CreateValidation(this ApproveChatJoinRequest value) =>
            new ValidationResult<ApproveChatJoinRequest>(value).ValidateRequired(x => x.ChatId)
                                                               .ValidateRequired(x => x.UserId);

        public static ValidationResult<DeclineChatJoinRequest> CreateValidation(this DeclineChatJoinRequest value) =>
            new ValidationResult<DeclineChatJoinRequest>(value).ValidateRequired(x => x.ChatId)
                                                               .ValidateRequired(x => x.UserId);
    }
}
