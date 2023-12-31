using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Utils;

public class ChatBoostSourceConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var sourceType = jsonObject.GetValue("source")
                                   ?.ToObject<ChatBoostSourceType>(serializer);

        return sourceType switch
               {
                   ChatBoostSourceType.GiftCode => jsonObject.ToObject<ChatBoostSourceGiftCode>(serializer),
                   ChatBoostSourceType.Premium => jsonObject.ToObject<ChatBoostSourcePremium>(serializer),
                   ChatBoostSourceType.Giveaway => jsonObject.ToObject<ChatBoostSourceGiveaway>(serializer),
                   _ => throw new NotSupportedException($"The specified type {sourceType} is not supported by this converter.")
               };
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(ChatBoostSource);

}
