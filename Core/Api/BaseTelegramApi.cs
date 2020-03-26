using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Core.Api
{
    public abstract class BaseTelegramApi
    {
        private readonly HttpClient _client = new HttpClient();

        protected BaseTelegramApi(BotInfo botInfo) => _client.BaseAddress = new Uri(botInfo.BotUrl);

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

        protected async Task<T> Get<T>(string uri) => await _client.GetAsync(uri)
                                                                   .ParseResponse<T>();

        protected async Task<T> Post<T>(string uri, object payload)
        {
            var serializer = JsonSerializer.Create(JsonSerializerSettings);
            var multipartFormDataContent = new MultipartFormDataContent("boundary" + Guid.NewGuid());
            var writer = new MultiPartJsonWriter(multipartFormDataContent);
            serializer.Serialize(writer, payload);

            StringContent stringContent = null;
            // use json, if we dont have stream contents (like photos, documents, etc.)
            if (!writer.StreamContent)
            {
                stringContent = new StringContent(writer.Token.ToString(Formatting.Indented), Encoding.UTF8, "application/json");
            }

            return await _client.PostAsync(uri, (HttpContent) stringContent ?? multipartFormDataContent)
                                .ParseResponse<T>();
        }
    }
}

