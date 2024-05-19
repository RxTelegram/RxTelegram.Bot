using System;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RxTelegram.Bot.Interface.ChatBackground;
using RxTelegram.Bot.Utils.Converter;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

[TestFixture]
public class BackgroundTypeConverterTest
{
    private readonly JsonSerializerSettings _jsonSettings = new()
                                                            {
                                                                Converters = { new MultiTypeClassConverter() }
                                                            };

    [Test]
    [TestCase("chat_theme", typeof(BackgroundTypeChatTheme))]
    [TestCase("fill", typeof(BackgroundTypeFill))]
    [TestCase("pattern", typeof(BackgroundTypePattern))]
    [TestCase("wallpaper", typeof(BackgroundTypeWallpaper))]
    public void CanRead(string type, Type expectedType)
    {
        var json = $"{{\"type\":\"{type}\"}}";
        var actual = JsonConvert.DeserializeObject<BackgroundType>(json, _jsonSettings);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.GetType(), Is.EqualTo(expectedType));
    }

    [Test]
    public void CanReadNull()
    {
        const string json = "{}";
        var actual = JsonConvert.DeserializeObject<BackgroundType>(json, _jsonSettings);
        Assert.That(actual, Is.Null);
    }

    [Test]
    [TestCase(typeof(BackgroundFillFreeformGradient), 0)]
    [TestCase(typeof(BackgroundFillGradient), 1)]
    [TestCase(typeof(BackgroundFillSolid), 2)]
    public void CanWrite(Type type, int expectedType)
    {
        var instance = Activator.CreateInstance(type);
        var json = JsonConvert.SerializeObject(instance, _jsonSettings);
        Assert.That(json, new StartsWithConstraint($"{{\"Type\":{expectedType}"));
    }

    [Test]
    public void CanWriteNull()
    {
        var json = JsonConvert.SerializeObject(null, _jsonSettings);
        Assert.That(json, Is.EqualTo("null"));
    }
}
