using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using TelegramInterface.BaseTypes;
using TelegramInterface.BaseTypes.Requests;

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
                                  new UnixDateTimeConverter()
                              };
                return _jsonSerializerSettings = new JsonSerializerSettings
                                                 {
                                                     ContractResolver = contractResolver,
                                                     Converters = convert
                                                 };
            }
        }

        public Task<User> GetMe() => Get<User>("getMe");

        public Task<Message> PostMessage(SendMessage message) => Post<Message>("sendMessage", message);

        private async Task<T> Get<T>(string uri) => await _client.GetAsync(uri)
                                                                 .ParseResponse<T>();

        private async Task<T> Post<T>(string uri, object payload)
        {
            var stringPayload = JsonConvert.SerializeObject(payload, JsonSerializerSettings);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            return await _client.PostAsync(uri, httpContent)
                                .ParseResponse<T>();
        }
    }
}
