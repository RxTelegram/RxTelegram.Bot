using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        private async Task<T> Get<T>(string uri) => await _client.GetAsync(uri)
                                                                 .ParseResponse<T>();

        private async Task<T> Post<T>(string uri, object payload)
        {
            // if any input file use a stream we need to send the files as form data instread of json
            var formDataRequest = Reflection.FindInputFileRecursive(payload)
                                .Where(x => x.Stream != null)
                                .ToList();

            HttpContent httpContent;
            if (formDataRequest.Any())
            {
                throw new NotImplementedException();
            }
            else
            {
                var stringPayload = JsonConvert.SerializeObject(payload, JsonSerializerSettings);
                httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            }

            return await _client.PostAsync(uri, httpContent)
                                .ParseResponse<T>();
        }
    }
}
