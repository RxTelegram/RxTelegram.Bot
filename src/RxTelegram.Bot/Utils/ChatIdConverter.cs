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
            if (value is ChatId chatId)
            {
                if (!string.IsNullOrEmpty(chatId.Username))
                {
                    writer.WriteValue(chatId.Username);
                }
                else
                {
                    writer.WriteValue(chatId.Identifier);
                }
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
            JsonSerializer serializer) => JToken.ReadFrom(reader)
                                                .Value<string>();
    }
}
