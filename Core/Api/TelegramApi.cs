using System.Threading.Tasks;
using TelegramInterface.BaseTypes;
using TelegramInterface.BaseTypes.Requests.Attachments;
using TelegramInterface.BaseTypes.Requests.Messages;

namespace Core.Api
{
    public class TelegramApi : BaseTelegramApi
    {
        public TelegramApi(BotInfo botInfo) : base(botInfo)
        {
        }

        public Task<User> GetMe() => Get<User>("getMe");

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
    }
}
