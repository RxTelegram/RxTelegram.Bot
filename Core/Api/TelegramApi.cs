using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using TelegramInterface.BaseTypes;
using TelegramInterface.BaseTypes.Requests.Attachments;
using TelegramInterface.BaseTypes.Requests.Messages;

namespace Core.Api
{
    public class TelegramApi
    {
        private readonly HttpClient _client = new HttpClient();

        public TelegramApi(BotInfo botInfo) => _client.BaseAddress = new Uri(botInfo.BotUrl);

        private static JsonSerializerSettings _jsonSerializerSettings;

        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                if (_jsonSerializerSettings != null)
                {
                    return _jsonSerializerSettings;
                }

                var contractResolver = new DefaultContractResolver
                                       {
                                           NamingStrategy = new SnakeCaseNamingStrategy()
                                       };
                var convert = new List<JsonConverter>
                              {
                                  new UnixDateTimeConverter(),
                                  new InputFileConverter()
                              };
                return _jsonSerializerSettings = new JsonSerializerSettings
                                                 {
                                                     ContractResolver = contractResolver,
                                                     Converters = convert,
                                                     NullValueHandling = NullValueHandling.Ignore
                                                 };
            }
        }

        public Task<User> GetMe() => Get<User>("getMe");

        public Task<Message> SendMessage(SendMessage message) => Post<Message>("sendMessage", message);

        public Task<Message> SendPhoto(SendPhoto message) => Post<Message>("sendPhoto", message);

        public Task<Message> SendDocument(SendDocument message) => Post<Message>("sendDocument", message);

        public Task<Message> SendMediaGroup(SendMediaGroup message) => Post<Message>("sendMediaGroup", message);

        private async Task<T> Get<T>(string uri) => await _client.GetAsync(uri)
                                                                 .ParseResponse<T>();

        private async Task<T> Post<T>(string uri, object payload)
        {
            var serializer = JsonSerializer.Create(JsonSerializerSettings);
            var multipartFormDataContent = new MultipartFormDataContent("boundray" + Guid.NewGuid());
            using (var writer = new MultiPartJsonWriter(multipartFormDataContent))
            {
                serializer.Serialize(writer, payload);
            }

            return await _client.PostAsync(uri, multipartFormDataContent)
                                .ParseResponse<T>();
        }
    }
}
