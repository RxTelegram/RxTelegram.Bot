using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Callbacks;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
using RxTelegram.Bot.Interface.Games;
using RxTelegram.Bot.Interface.Games.Requests;
using RxTelegram.Bot.Interface.Passport.Requests;
using RxTelegram.Bot.Interface.Payments.Requests;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Requests;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot
{
    public class TelegramBot : BaseTelegramBot
    {
        public IUpdateManager Updates { get; }

        public TelegramBot(string token) : this(new BotInfo(token))
        {
        }

        public TelegramBot(BotInfo botInfo) : base(botInfo) => Updates = new UpdateManager(this);

        #region Updates

        public Task<Update[]> GetUpdate(GetUpdate update, CancellationToken cancellationToken = default) =>
            Get<Update[]>("getUpdates", update, cancellationToken);

        public Task<bool> SetWebhook(SetWebhook update, CancellationToken cancellationToken = default) =>
            Get<bool>("setWebhook", update, cancellationToken);

        public Task<bool> DeleteWebhook(CancellationToken cancellationToken = default) =>
            Get<bool>("deleteWebhook", default, cancellationToken);

        public Task<WebhookInfo> GetWebhookInfo(CancellationToken cancellationToken = default) =>
            Get<WebhookInfo>("getWebhookInfo", default, cancellationToken);

        #endregion

        public Task<File> GetFile(string fileId, CancellationToken cancellationToken = default) =>
            Get<File>("getFile", new {fileId}, cancellationToken);

        public Task<Stream> DownloadFileStream(string filePath) => FileClient.GetStreamAsync(filePath);

        public Task<string> DownloadFileString(string filePath) => FileClient.GetStringAsync(filePath);

        public Task<byte[]> DownloadFileByteArray(string filePath) => FileClient.GetByteArrayAsync(filePath);

        public Task<User> GetMe(CancellationToken cancellationToken = default) => Get<User>("getMe", cancellationToken: cancellationToken);

        public Task<Message> SendMessage(SendMessage message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendMessage", message, cancellationToken);

        public Task<Message> ForwardMessage(ForwardMessage forwardMessage, CancellationToken cancellationToken = default) =>
            Post<Message>("forwardMessage", forwardMessage, cancellationToken);

        public Task<Message> SendPhoto(SendPhoto message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendPhoto", message, cancellationToken);

        public Task<Message> SendAudio(SendAudio message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendAudio", message, cancellationToken);

        public Task<Message> SendDocument(SendDocument message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendDocument", message, cancellationToken);

        public Task<Message> SendVideo(SendVideo message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendVideo", message, cancellationToken);

        public Task<Message> SendAnimation(SendAnimation message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendAnimation", message, cancellationToken);

        public Task<Message> SendVoice(SendVoice message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendVoice", message, cancellationToken);

        public Task<Message> SendVideoNote(SendVideoNote message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendVideoNote", message, cancellationToken);

        public Task<Message[]> SendMediaGroup(SendMediaGroup message, CancellationToken cancellationToken = default) =>
            Post<Message[]>("sendMediaGroup", message, cancellationToken);

        public Task<Message> SendLocation(SendLocation message, CancellationToken cancellationToken = default) =>
            Post<Message>("sendLocation", message, cancellationToken);

        public Task<bool> CreateNewStickerSet(CreateNewStickerSet createNewStickerSet, CancellationToken cancellationToken = default) =>
            Post<bool>("createNewStickerSet", createNewStickerSet, cancellationToken);

        public Task<Message> EditMessageLiveLocation(
            EditMessageLiveLocation editMessageLiveLocation,
            CancellationToken cancellationToken = default) =>
            Post<Message>("editMessageLiveLocation", editMessageLiveLocation, cancellationToken);

        public Task<Chat> GetChat(GetChat getChat, CancellationToken cancellationToken = default) =>
            Post<Chat>("getChat", getChat, cancellationToken);

        public Task<ChatMember> GetChatMember(GetChatMember getChatMember, CancellationToken cancellationToken = default) =>
            Post<ChatMember>("getChatMember", getChatMember, cancellationToken);

        public Task<StickerSet> GetStickerSet(GetStickerSet getStickerSet, CancellationToken cancellationToken = default) =>
            Post<StickerSet>("getStickerSet", getStickerSet, cancellationToken);

        public Task<UserProfilePhotos> GetUserProfilePhotos(
            GetUserProfilePhotos getUserProfilePhotos,
            CancellationToken cancellationToken = default) =>
            Post<UserProfilePhotos>("getUserProfilePhotos", getUserProfilePhotos, cancellationToken);

        public Task<IEnumerable<ChatMember>> GetChatAdministrators(
            GetChatAdministrators getChatAdministrators,
            CancellationToken cancellationToken = default) =>
            Post<IEnumerable<ChatMember>>("getChatAdministrators", getChatAdministrators, cancellationToken);

        public Task<int> GetChatMembersCount(GetChatMembersCount getChatMembersCount, CancellationToken cancellationToken = default) =>
            Post<int>("getChatMembersCount", getChatMembersCount, cancellationToken);

        public Task<bool> KickChatMember(KickChatMember kickChatMember, CancellationToken cancellationToken = default) =>
            Post<bool>("kickChatMember", kickChatMember, cancellationToken);

        public Task<bool> DeleteMessage(DeleteMessage deleteMessage, CancellationToken cancellationToken = default) =>
            Post<bool>("deleteMessage", deleteMessage, cancellationToken);

        public Task<bool> DeleteChatPhoto(DeleteChatPhoto deleteChatPhoto, CancellationToken cancellationToken = default) =>
            Post<bool>("deleteChatPhoto", deleteChatPhoto, cancellationToken);

        public Task<bool> LeaveChat(LeaveChat leaveChat, CancellationToken cancellationToken = default) =>
            Post<bool>("leaveChat", leaveChat, cancellationToken);

        public Task<bool> AddStickerToSet(AddStickerToSet addStickerToSet, CancellationToken cancellationToken = default) =>
            Post<bool>("addStickerToSet", addStickerToSet, cancellationToken);

        public Task<bool> DeleteStickerFromSet(DeleteStickerFromSet deleteStickerFromSet, CancellationToken cancellationToken = default) =>
            Post<bool>("deleteStickerFromSet", deleteStickerFromSet, cancellationToken);

        public Task<bool> PinChatMessage(PinChatMessage pinChatMessage, CancellationToken cancellationToken = default) =>
            Post<bool>("pinChatMessage", pinChatMessage, cancellationToken);

        public Task<bool> UnpinChatMessage(UnpinChatMessage unpinChatMessage, CancellationToken cancellationToken = default) =>
            Post<bool>("unpinChatMessage", unpinChatMessage, cancellationToken);

        public Task<bool> SetChatDescription(SetChatDescription setChatDescription, CancellationToken cancellationToken = default) =>
            Post<bool>("setChatDescription", setChatDescription, cancellationToken);

        public Task<bool> SetChatPermissions(SetChatPermissions setChatPermissions, CancellationToken cancellationToken = default) =>
            Post<bool>("setChatPermissions", setChatPermissions, cancellationToken);

        public Task<bool> SetChatTitle(SetChatTitle setChatTitle, CancellationToken cancellationToken = default) =>
            Post<bool>("setChatTitle", setChatTitle, cancellationToken);

        public Task<bool> SetChatStickerSet(SetChatStickerSet setChatStickerSet, CancellationToken cancellationToken = default) =>
            Post<bool>("setChatStickerSet", setChatStickerSet, cancellationToken);

        public Task<bool> DeleteChatStickerSet(DeleteChatStickerSet deleteChatStickerSet, CancellationToken cancellationToken = default) =>
            Post<bool>("deleteChatStickerSet", deleteChatStickerSet, cancellationToken);

        public Task<bool> SetStickerSetThumb(SetStickerSetThumb setStickerSetThumb, CancellationToken cancellationToken = default) =>
            Post<bool>("setStickerSetThumb", setStickerSetThumb, cancellationToken);

        public Task<Message> SendSticker(SendSticker sendSticker, CancellationToken cancellationToken = default) =>
            Post<Message>("sendSticker", sendSticker, cancellationToken);

        public Task<bool> SetChatPhoto(SetChatPhoto setChatPhoto, CancellationToken cancellationToken = default) =>
            Post<bool>("setChatPhoto", setChatPhoto, cancellationToken);

        public Task<string>
            ExportChatInviteLink(ExportChatInviteLink exportChatInviteLink, CancellationToken cancellationToken = default) =>
            Post<string>("exportChatInviteLink", exportChatInviteLink, cancellationToken);

        public Task<bool> PromoteChatMember(PromoteChatMember promoteChatMember, CancellationToken cancellationToken = default) =>
            Post<bool>("promoteChatMember", promoteChatMember, cancellationToken);

        public Task<bool> RestrictChatMember(RestrictChatMember restrictChatMember, CancellationToken cancellationToken = default) =>
            Post<bool>("restrictChatMember", restrictChatMember, cancellationToken);

        public Task<Message> SendContact(SendContact sendContact, CancellationToken cancellationToken = default) =>
            Post<Message>("sendContact", sendContact, cancellationToken);

        public Task<File> UploadStickerFile(UploadStickerFile uploadStickerFile, CancellationToken cancellationToken = default) =>
            Post<File>("uploadStickerFile", uploadStickerFile, cancellationToken);

        public Task<Message> EditMessageText(EditMessageText editMessageText, CancellationToken cancellationToken = default) =>
            Post<Message>("editMessageText", editMessageText, cancellationToken);

        public Task<bool> SetStickerPositionInSet(
            SetStickerPositionInSet setStickerPositionInSet,
            CancellationToken cancellationToken = default) =>
            Post<bool>("setStickerPositionInSet", setStickerPositionInSet, cancellationToken);

        public Task<bool> SendChatAction(SendChatAction sendChatAction, CancellationToken cancellationToken = default) =>
            Post<bool>("sendChatAction", sendChatAction, cancellationToken);

        public Task<bool> SendPoll(SendPoll sendPoll, CancellationToken cancellationToken = default) =>
            Post<bool>("sendPoll", sendPoll, cancellationToken);

        public Task<Poll> StopPoll(StopPoll stopPoll, CancellationToken cancellationToken = default) =>
            Post<Poll>("stopPoll", stopPoll, cancellationToken);

        public Task<bool> SetChatAdministratorCustomTitle(
            SetChatAdministratorCustomTitle setChatAdministratorCustomTitle,
            CancellationToken cancellationToken = default) =>
            Post<bool>("setChatAdministratorCustomTitle", setChatAdministratorCustomTitle, cancellationToken);

        public Task<bool> UnbanChatMember(UnbanChatMember unbanChatMember, CancellationToken cancellationToken = default) =>
            Post<bool>("unbanChatMember", unbanChatMember, cancellationToken);

        public Task<Message> SendGame(SendGame sendGame, CancellationToken cancellationToken = default) =>
            Post<Message>("sendGame", sendGame, cancellationToken);

        public Task<bool> SetGameScoreInlineMessage(SetGameScore setGameScore, CancellationToken cancellationToken = default) =>
            Post<bool>("setGameScore", setGameScore, cancellationToken);

        public Task<Message> SetGameScore(SetGameScore setGameScore, CancellationToken cancellationToken = default) =>
            Post<Message>("setGameScore", setGameScore, cancellationToken);

        public Task<IEnumerable<GameHighScore>> GetGameHighScores(
            GetGameHighScores getGameHighScores,
            CancellationToken cancellationToken = default) =>
            Post<IEnumerable<GameHighScore>>("getGameHighScores", getGameHighScores, cancellationToken);

        public Task<Message> StopMessageLiveLocation(
            StopMessageLiveLocation stopMessageLiveLocation,
            CancellationToken cancellationToken = default) =>
            Post<Message>("stopMessageLiveLocation", stopMessageLiveLocation, cancellationToken);

        public Task<bool> StopMessageLiveLocationInlineMessage(
            StopMessageLiveLocation stopMessageLiveLocation,
            CancellationToken cancellationToken = default) =>
            Post<bool>("stopMessageLiveLocation", stopMessageLiveLocation, cancellationToken);

        public Task<bool> AnswerCallbackQuery(AnswerCallbackQuery answerCallbackQuery, CancellationToken cancellationToken = default) =>
            Post<bool>("answerCallbackQuery", answerCallbackQuery, cancellationToken);

        public Task<bool> AnswerInlineQuery(AnswerInlineQuery answerInlineQuery, CancellationToken cancellationToken = default) =>
            Post<bool>("answerInlineQuery", answerInlineQuery, cancellationToken);

        public Task<IEnumerable<BotCommand>> GetMyCommands(CancellationToken cancellationToken = default) =>
            Get<IEnumerable<BotCommand>>("getMyCommands", default, cancellationToken);

        public Task<bool> SetMyCommands(SetMyCommands setMyCommands, CancellationToken cancellationToken = default) =>
            Post<bool>("setMyCommands", setMyCommands, cancellationToken);

        public Task<Message> SendVenue(SendVenue sendVenue, CancellationToken cancellationToken = default) =>
            Post<Message>("sendVenue", sendVenue, cancellationToken);

        public Task<Message> EditMessageCaption(EditMessageCaption sendLocation, CancellationToken cancellationToken = default) =>
            Post<Message>("editMessageCaption", sendLocation, cancellationToken);

        public Task<Message> EditMessageReplyMarkup(
            EditMessageReplyMarkup editMessageReplyMarkup,
            CancellationToken cancellationToken = default) =>
            Post<Message>("editMessageReplyMarkup", editMessageReplyMarkup, cancellationToken);

        public Task<Message> SendInvoice(SendInvoice sendInvoice, CancellationToken cancellationToken = default) =>
            Post<Message>("sendInvoice", sendInvoice, cancellationToken);

        public Task<bool> AnswerShippingQuery(AnswerShippingQuery answerShippingQuery, CancellationToken cancellationToken = default) =>
            Post<bool>("answerShippingQuery", answerShippingQuery, cancellationToken);

        public Task<bool> AnswerPreCheckoutQuery(
            AnswerPreCheckoutQuery answerPreCheckoutQuery,
            CancellationToken cancellationToken = default) =>
            Post<bool>("answerPreCheckoutQuery", answerPreCheckoutQuery, cancellationToken);

        public Task<bool> SetPassportDataErrors(
            SetPassportDataErrors setPassportDataErrors,
            CancellationToken cancellationToken = default) =>
            Post<bool>("setPassportDataErrors", setPassportDataErrors, cancellationToken);

        public Task<bool> EditMessageMedia(
            EditMessageMedia editMessageMedia,
            CancellationToken cancellationToken = default) =>
            Post<bool>("editMessageMedia", editMessageMedia, cancellationToken);

        public Task<Message> SendDice(
            SendDice sendDice,
            CancellationToken cancellationToken = default) =>
            Post<Message>("sendDice", sendDice, cancellationToken);
    }
}
