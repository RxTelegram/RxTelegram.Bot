using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace RxTelegram.Bot.Utils.Converter;

public class UnknownStringEnumConverter(NamingStrategy namingStrategy) : StringEnumConverter(namingStrategy)
{
    public override object ReadJson(JsonReader reader, Type enumType, object existingValue, JsonSerializer serializer)
    {
        try
        {
            return base.ReadJson(reader, enumType, existingValue, serializer);
        }
        catch (Exception) when (enumType.IsEnum ||
                                enumType.IsGenericType &&
                                enumType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                                enumType.GenericTypeArguments[0].IsEnum)
        {
            // Return null if it is a nullable enum and -1 if it is an enum to ensure that new values do not brake the bot
            return reader.TokenType switch
                   {
                       JsonToken.Integer => Enum.ToObject(enumType, -1),
                       JsonToken.Null => null,
                       JsonToken.None => null,
                       JsonToken.String when enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>) => null,
                       JsonToken.String => Enum.ToObject(enumType, -1),
                       _ => throw new ArgumentOutOfRangeException()
                   };
        }
    }
}
