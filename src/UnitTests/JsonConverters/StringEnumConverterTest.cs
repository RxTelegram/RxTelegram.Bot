using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Passport.Enum;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Enums;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

[TestFixture]
public class StringEnumConverterTest : BaseConverterTest
{
    [Test]
    public void SerializeElementType()
    {
        var objectToSerialize = new
                                {
                                    elementType = ElementType.BankStatement
                                };

        var json = JsonConvert.SerializeObject(objectToSerialize, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains("bank_statement"), Is.True);
    }

    [Test]
    public void SerializeParseMode()
    {
        var objectToSerialize = new
                                {
                                    parse = ParseMode.Markdown
                                };

        var json = JsonConvert.SerializeObject(objectToSerialize, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains("markdown"), Is.True);
    }

    [Test]
    public void SerializeStickerType()
    {
        var sicker = new Sticker
                     {
                         Type = StickerType.CustomEmoji
                     };
        var json = JsonConvert.SerializeObject(sicker, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains("custom_emoji"), Is.True);
    }
}
