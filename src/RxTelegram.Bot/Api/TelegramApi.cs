using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
using RxTelegram.Bot.Interface.Games;
using RxTelegram.Bot.Interface.Games.Requests;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Requests;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot.Api
{
    public class TelegramApi : BaseTelegramApi
    {
        public IUpdateManager Updates { get; }

        public TelegramApi(BotInfo botInfo) : base(botInfo) => Updates = new UpdateManager(this);

        public Task<Update[]> GetUpdate(GetUpdate update) => Get<Update[]>("getUpdates", update);

        public Task<File> GetFile(string fileId) => Get<File>("getFile", new {fileId});

        public Task<Stream> DownloadFileStream(string filePath) => FileClient.GetStreamAsync(filePath);

        public Task<string> DownloadFileString(string filePath) => FileClient.GetStringAsync(filePath);

        public Task<byte[]> DownloadFileByteArray(string filePath) => FileClient.GetByteArrayAsync(filePath);

        public Task<User> GetMe() => Get<User>("getMe");

        public Task<Message> SendMessage(SendMessage message) => Post<Message>("sendMessage", message);

        public Task<Message> ForwardMessage(ForwardMessage forwardMessage) => Post<Message>("forwardMessage", forwardMessage);

        public Task<Message> SendPhoto(SendPhoto message) => Post<Message>("sendPhoto", message);

        public Task<Message> SendAudio(SendAudio message) => Post<Message>("sendAudio", message);

        public Task<Message> SendDocument(SendDocument message) => Post<Message>("sendDocument", message);

        public Task<Message> SendVideo(SendVideo message) => Post<Message>("sendVideo", message);

        public Task<Message> SendAnimation(SendAnimation message) => Post<Message>("sendAnimation", message);

        public Task<Message> SendVoice(SendVoice message) => Post<Message>("sendVoice", message);

        public Task<Message> SendVideoNote(SendVideoNote message) => Post<Message>("sendVideoNote", message);

        public Task<Message[]> SendMediaGroup(SendMediaGroup message) => Post<Message[]>("sendMediaGroup", message);

        public Task<Message> SendLocation(SendLocation message) => Post<Message>("sendLocation", message);

        public Task<bool> CreateNewStickerSet(CreateNewStickerSet createNewStickerSet) =>
            Post<bool>("createNewStickerSet", createNewStickerSet);

        public Task<Message> EditMessageLiveLocation(EditMessageLiveLocation editMessageLiveLocation) =>
            Post<Message>("editMessageLiveLocation", editMessageLiveLocation);

        public Task<Chat> GetChat(GetChat getChat) => Post<Chat>("getChat", getChat);

        public Task<ChatMember> GetChatMember(GetChatMember getChatMember) => Post<ChatMember>("getChatMember", getChatMember);

        public Task<StickerSet> GetStickerSet(GetStickerSet getStickerSet) => Post<StickerSet>("getStickerSet", getStickerSet);

        public Task<UserProfilePhotos> GetUserProfilePhotos(GetUserProfilePhotos getUserProfilePhotos) =>
            Post<UserProfilePhotos>("getUserProfilePhotos", getUserProfilePhotos);

        public Task<IEnumerable<ChatMember>> GetChatAdministrators(GetChatAdministrators getChatAdministrators) =>
            Post<IEnumerable<ChatMember>>("getChatAdministrators", getChatAdministrators);

        public Task<int> GetChatMembersCount(GetChatMembersCount getChatMembersCount) =>
            Post<int>("getChatMembersCount", getChatMembersCount);

        public Task<bool> KickChatMember(KickChatMember kickChatMember) => Post<bool>("kickChatMember", kickChatMember);

        public Task<bool> DeleteMessage(DeleteMessage deleteMessage) => Post<bool>("deleteMessage", deleteMessage);

        public Task<bool> DeleteChatPhoto(DeleteChatPhoto deleteChatPhoto) => Post<bool>("deleteChatPhoto", deleteChatPhoto);

        public Task<bool> LeaveChat(LeaveChat leaveChat) => Post<bool>("leaveChat", leaveChat);

        public Task<bool> AddStickerToSet(AddStickerToSet addStickerToSet) => Post<bool>("addStickerToSet", addStickerToSet);

        public Task<bool> DeleteStickerFromSet(DeleteStickerFromSet deleteStickerFromSet) =>
            Post<bool>("deleteStickerFromSet", deleteStickerFromSet);

        public Task<bool> PinChatMessage(PinChatMessage pinChatMessage) => Post<bool>("pinChatMessage", pinChatMessage);

        public Task<bool> UnpinChatMessage(UnpinChatMessage unpinChatMessage) => Post<bool>("unpinChatMessage", unpinChatMessage);

        public Task<bool> SetChatDescription(SetChatDescription setChatDescription) => Post<bool>("setChatDescription", setChatDescription);

        public Task<bool> SetChatPermissions(SetChatPermissions setChatPermissions) => Post<bool>("setChatPermissions", setChatPermissions);

        public Task<bool> SetChatTitle(SetChatTitle setChatTitle) => Post<bool>("setChatTitle", setChatTitle);

        public Task<bool> SetChatStickerSet(SetChatStickerSet setChatStickerSet) => Post<bool>("setChatStickerSet", setChatStickerSet);

        public Task<Message> SendSticker(SendSticker sendSticker) => Post<Message>("sendSticker", sendSticker);

        public Task<bool> SetChatPhoto(SetChatPhoto setChatPhoto) => Post<bool>("setChatPhoto", setChatPhoto);

        public Task<string> ExportChatInviteLink(ExportChatInviteLink exportChatInviteLink) =>
            Post<string>("exportChatInviteLink", exportChatInviteLink);

        public Task<bool> PromoteChatMember(PromoteChatMember promoteChatMember) => Post<bool>("promoteChatMember", promoteChatMember);

        public Task<bool> RestrictChatMember(RestrictChatMember restrictChatMember) => Post<bool>("restrictChatMember", restrictChatMember);

        public Task<Message> SendContact(SendContact sendContact) => Post<Message>("sendContact", sendContact);

        public Task<File> UploadStickerFile(UploadStickerFile uploadStickerFile) => Post<File>("uploadStickerFile", uploadStickerFile);

        public Task<Message> EditMessageText(EditMessageText editMessageText) => Post<Message>("editMessageText", editMessageText);

        public Task<bool> SetStickerPositionInSet(SetStickerPositionInSet setStickerPositionInSet) =>
            Post<bool>("setStickerPositionInSet", setStickerPositionInSet);

        public Task<bool> SendChatAction(SendChatAction sendChatAction) => Post<bool>("sendChatAction", sendChatAction);

        public Task<bool> SendPoll(SendPoll sendPoll) => Post<bool>("sendPoll", sendPoll);

        public Task<Poll> StopPoll(StopPoll stopPoll) => Post<Poll>("stopPoll", stopPoll);

        public Task<bool> SetChatAdministratorCustomTitle(SetChatAdministratorCustomTitle setChatAdministratorCustomTitle) =>
            Post<bool>("setChatAdministratorCustomTitle", setChatAdministratorCustomTitle);

        public Task<bool> UnbanChatMember(UnbanChatMember unbanChatMember) => Post<bool>("unbanChatMember", unbanChatMember);

        public Task<Message> SendGame(SendGame sendGame) => Post<Message>("sendGame", sendGame);

        public Task<bool> SetGameScoreInlineMessage(SetGameScore setGameScore) => Post<bool>("setGameScore", setGameScore);

        public Task<Message> SetGameScore(SetGameScore setGameScore) => Post<Message>("setGameScore", setGameScore);

        public Task<IEnumerable<GameHighScore>> GetGameHighScores(GetGameHighScores getGameHighScores) =>
            Post<IEnumerable<GameHighScore>>("getGameHighScores", getGameHighScores);

        public Task<Message> StopMessageLiveLocation(StopMessageLiveLocation stopMessageLiveLocation) =>
            Post<Message>("stopMessageLiveLocation", stopMessageLiveLocation);

        public Task<bool> StopMessageLiveLocationInlineMessage(StopMessageLiveLocation stopMessageLiveLocation) =>
            Post<bool>("stopMessageLiveLocation", stopMessageLiveLocation);
    }
}
