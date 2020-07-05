using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils
{
    public class ChatIdConverter : JsonConverter<ChatId>
    {
        public override void WriteJson(JsonWriter writer, ChatId value, JsonSerializer serializer)
        {
            if (!string.IsNullOrEmpty(value.Username))
            {
                writer.WriteValue(value.Username);
            }
            else if (value.Identifier.HasValue)
            {
                writer.WriteValue(value.Identifier);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override ChatId ReadJson(
            JsonReader reader,
            Type objectType,
            ChatId existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = JToken.ReadFrom(reader);
            switch (value.Type)
            {
                case JTokenType.Integer:
                    return value.Value<long>();
                case JTokenType.String:
                    return value.Value<string>();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
