using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Utils.Converter;

public class MultiTypeClassConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        CheckForValidInterfaces(objectType);
        var distinguishingProperty = GetNameOfDistinguishingProperty(objectType);
        var jsonObject = JObject.Load(reader);
        var valueToDefineResultType = jsonObject.GetValue(distinguishingProperty) ??
                                      throw new InvalidOperationException("The property is not found");
        var resultTypeEnum = GetEnumOfGenericInterface(objectType);
        var propertyName = ToPascalCase(valueToDefineResultType.Value<string>());

        // Get Attribute for enum entry
        var attributeOfEnumValue = resultTypeEnum.GetField(propertyName)
                                                 .GetCustomAttributes(typeof(ImplementationTypeAttribute), false)
                                                 .Cast<ImplementationTypeAttribute>()
                                                 .FirstOrDefault();
        if (attributeOfEnumValue == null)
        {
            throw new InvalidOperationException($"The specified type {valueToDefineResultType} is not supported by this converter.");
        }

        // Populate the object
        var attributesType = attributeOfEnumValue.ImplementationType;
        var objectInstance = Activator.CreateInstance(attributesType) ?? throw new InvalidOperationException();
        serializer.Populate(jsonObject.CreateReader(), objectInstance);
        return objectInstance;
    }

    private static Type GetEnumOfGenericInterface(Type objectType)
    {
        var interfaces = objectType.GetInterfaces();
        var valueToDefineResultType =
            Array.Find(interfaces, x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassBySource<>)) ??
            Array.Find(interfaces, x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassByType<>));

        var resultTypeEnum = valueToDefineResultType?.GetGenericArguments()
                                                    .FirstOrDefault();
        if (resultTypeEnum == null)
        {
            throw new NotSupportedException($"The specified type {valueToDefineResultType} is not supported by this converter.");
        }

        return resultTypeEnum;
    }

    private static void CheckForValidInterfaces(Type objectType)
    {
        var destinationObjectAttributes = objectType.GetInterfaces();
        if (!destinationObjectAttributes.Any())
        {
            throw new NotSupportedException($"The specified type {objectType} is not supported by this converter.");
        }

        if (Array.Exists(destinationObjectAttributes,
                         x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassBySource<>)) &&
            Array.Exists(destinationObjectAttributes,
                         x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassByType<>)))
        {
            throw new NotSupportedException($"The specified type {objectType} is not supported by this converter.");
        }
    }

    private static string GetNameOfDistinguishingProperty(Type objectType)
    {
        var distinguishingProperty = "";

        // Determine if object is MultiTypeClass by source or type
        var destinationObjectAttributes = objectType.GetInterfaces();
        if (Array.Exists(destinationObjectAttributes,
                         x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassBySource<>)))
        {
            distinguishingProperty = "source";
        }

        if (Array.Exists(destinationObjectAttributes,
                         x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMultiTypeClassByType<>)))
        {
            distinguishingProperty = "type";
        }

        return distinguishingProperty;
    }

    private static string ToPascalCase(string str)
    {
        var textInfo = new CultureInfo("en-US", false).TextInfo;

        // Split the string by underscores
        var words = str.Split('_');

        // Capitalize each word and concatenate
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = textInfo.ToTitleCase(words[i]);
        }

        // Join the words together without spaces
        return string.Concat(words);
    }

    public override bool CanConvert(Type objectType) => objectType.IsAbstract &&
                                                        Array.Exists(objectType.GetInterfaces(),
                                                                     x => x.IsGenericType &&
                                                                          (x.GetGenericTypeDefinition() ==
                                                                           typeof(IMultiTypeClassBySource<>) ||
                                                                           x.GetGenericTypeDefinition() ==
                                                                           typeof(IMultiTypeClassByType<>)));
}
