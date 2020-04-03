using System.Collections.Generic;
using System.Threading.Tasks;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Requests;

namespace RxTelegram.Bot.Api
{
    public class TelegramApi : BaseTelegramApi
    {
        public IUpdateManager Updates { get; }

        public TelegramApi(BotInfo botInfo) : base(botInfo) => Updates = new UpdateManager(this);

        public Task<User> GetMe() => Get<User>("getMe");

        public Task<Update[]> GetUpdate(GetUpdate update) => Get<Update[]>("getUpdates", update);

        public Task<Message> SendMessage(SendMessage message) => Post<Message>("sendMessage", message);

        public Task<Message> SendPhoto(SendPhoto message) => Post<Message>("sendPhoto", message);

        public Task<Message> SendAudio(SendAudio message) => Post<Message>("sendAudio", message);

        public Task<Message> SendDocument(SendDocument message) => Post<Message>("sendDocument", message);

        public Task<Message> SendVideo(SendVideo message) => Post<Message>("sendVideo", message);

        public Task<Message> SendAnimation(SendAnimation message) => Post<Message>("sendAnimation", message);

        public Task<Message> SendVoice(SendVoice message) => Post<Message>("sendVoice", message);

        public Task<Message> SendVideoNote(SendVideoNote message) => Post<Message>("sendVideoNote", message);

        public Task<Message> SendMediaGroup(SendMediaGroup message) => Post<Message>("sendMediaGroup", message);

        public Task<Message> SendLocation(SendLocation message) => Post<Message>("sendLocation", message);

        public Task<Message> ForwardMessage(ForwardMessage forwardMessage) => Post<Message>("forwardMessage", forwardMessage);

        public Task<bool> CreateNewStickerSet(CreateNewStickerSet createNewStickerSet) =>
            Post<bool>("createNewStickerSet", createNewStickerSet);

        public Task<bool> EditMessageLiveLocation(EditMessageLiveLocation editMessageLiveLocation) =>
            Post<bool>("editMessageLiveLocation", editMessageLiveLocation);

        public Task<Chat> GetChat(GetChat getChat) => Post<Chat>("getChat", getChat);

        public Task<ChatMember> GetChatMember(GetChatMember getChatMember) => Post<ChatMember>("getChatMember", getChatMember);

        public Task<StickerSet> GetStickerSet(GetStickerSet getStickerSet) => Post<StickerSet>("getStickerSet", getStickerSet);

        public Task<UserProfilePhotos> GetUserProfilePhotos(GetUserProfilePhotos getUserProfilePhotos) =>
            Post<UserProfilePhotos>("getUserProfilePhotos", getUserProfilePhotos);

        public Task<IEnumerable<ChatMember>> GetChatAdministrators(GetChatAdministrators getChatAdministrators) =>
            Post<IEnumerable<ChatMember>>("getChatAdministrators", getChatAdministrators);
    }
}
