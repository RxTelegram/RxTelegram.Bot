using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.Converter;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

[TestFixture]
public class UnknownStringEnumConverterTest
{
    private readonly JsonSerializerSettings _jsonSettings = new()
                                                            {
                                                                Converters =
                                                                {
                                                                    new
                                                                        UnknownStringEnumConverter(new
                                                                                                       SnakeCaseNamingStrategy())
                                                                }
                                                            };

    [Test]
    [TestCase(@"""blockquote""", MessageEntityType.Blockquote)]
    [TestCase(@"""Pre""", MessageEntityType.Pre)]
    [TestCase(@"""code""", MessageEntityType.Code)]
    [TestCase(@"""mention""", MessageEntityType.Mention)]
    [TestCase(@"""url""", MessageEntityType.Url)]
    [TestCase(@"""email""", MessageEntityType.Email)]
    [TestCase(@"""bold""", MessageEntityType.Bold)]
    [TestCase(@"""italic""", MessageEntityType.Italic)]
    [TestCase(@"""spoiler""", MessageEntityType.Spoiler)]
    [TestCase(@"""hashtag""", MessageEntityType.Hashtag)]
    [TestCase(@"""bot_command""", MessageEntityType.BotCommand)]
    [TestCase(@"""custom_emoji""", MessageEntityType.CustomEmoji)]
    [TestCase(@"""text_link""", MessageEntityType.TextLink)]
    [TestCase(@"""text_mention""", MessageEntityType.TextMention)]
    [TestCase(@"""unknown""", MessageEntityType.Unknown)]
    [TestCase(@"""doesnt_exist""", null)]
    [TestCase("", null)]
    [TestCase(" ", null)]
    public void ReadJson_WithUnknownStringEnum_ReturnsEnumValueOrNull(string json, MessageEntityType? expected)
    {
        // Act
        var result = JsonConvert.DeserializeObject<MessageEntityType?>(json, _jsonSettings);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(@"""blockquote""", (int)MessageEntityType.Blockquote)]
    [TestCase(@"""Pre""", (int)MessageEntityType.Pre)]
    [TestCase(@"""code""", (int)MessageEntityType.Code)]
    [TestCase(@"""mention""", (int)MessageEntityType.Mention)]
    [TestCase(@"""url""", (int)MessageEntityType.Url)]
    [TestCase(@"""email""", (int)MessageEntityType.Email)]
    [TestCase(@"""bold""", (int)MessageEntityType.Bold)]
    [TestCase(@"""italic""", (int)MessageEntityType.Italic)]
    [TestCase(@"""spoiler""", (int)MessageEntityType.Spoiler)]
    [TestCase(@"""hashtag""", (int)MessageEntityType.Hashtag)]
    [TestCase(@"""bot_command""", (int)MessageEntityType.BotCommand)]
    [TestCase(@"""custom_emoji""", (int)MessageEntityType.CustomEmoji)]
    [TestCase(@"""text_link""", (int)MessageEntityType.TextLink)]
    [TestCase(@"""text_mention""", (int)MessageEntityType.TextMention)]
    [TestCase(@"""unknown""", (int)MessageEntityType.Unknown)]
    [TestCase(@"""doesnt_exist""", -1)]
    public void ReadJson_WithUnknownStringEnum_ReturnsEnumValueOrNegativeValue(string json, int expected)
    {
        // Act
        var result = JsonConvert.DeserializeObject<MessageEntityType>(json, _jsonSettings);

        // Assert
        Assert.That((int)result, Is.EqualTo(expected));
    }
}
