using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RxTelegram.Bot.Exceptions;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Utils;

namespace RxTelegram.Bot.Api
{
    public abstract class BaseTelegramBot
    {
        private readonly HttpClient _client = new HttpClient();

        protected readonly HttpClient FileClient = new HttpClient();

        protected BaseTelegramBot(BotInfo botInfo)
        {
            _client.BaseAddress = new Uri(botInfo.BotUrl);
            FileClient.BaseAddress = new Uri(botInfo.BotFileUrl);
        }

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
                                  new InputFileConverter(),
                                  new StringEnumConverter(new SnakeCaseNamingStrategy())
                              };
                return _jsonSerializerSettings = new JsonSerializerSettings
                                                 {
                                                     ContractResolver = contractResolver,
                                                     Converters = convert,
                                                     NullValueHandling = NullValueHandling.Ignore
                                                 };
            }
        }

        protected Task<T> Get<T>(string uri, object payload = default, CancellationToken cancellationToken = default) =>
            Request<T>(HttpMethod.Get, uri, payload, cancellationToken);

        protected Task<T> Post<T>(string uri, object payload, CancellationToken cancellationToken = default) =>
            Request<T>(HttpMethod.Post, uri, payload, cancellationToken);

        private async Task<T> Request<T>(HttpMethod httpMethod, string uri, object payload, CancellationToken cancellationToken = default)
        {
            HttpContent httpContent = null;
            if (payload != null)
            {
                if (payload is BaseValidation castedPayload)
                {
                    if (!castedPayload.IsValid())
                    {
                        throw new RequestValidationException(castedPayload.Errors);
                    }
                }

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

                httpContent = (HttpContent) stringContent ?? multipartFormDataContent;

            }

            var httpRequest = new HttpRequestMessage(httpMethod, uri)
                              {
                                  Content = httpContent
                              };
            return await _client.SendAsync(httpRequest, cancellationToken)
                                .ParseResponse<T>();
        }
    }
}

