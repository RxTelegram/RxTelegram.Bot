using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

[TestFixture]
public class ChatIdConverterTest : BaseConverterTest
{
    [Test]
    public void ShouldDeserializeIntChatId()
    {
        const string json = "{ \"chat_id\":2147483647}";
        var deserializedJson = JsonConvert.DeserializeObject<ForwardMessage>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.ChatId.Identifier == int.MaxValue, Is.True);
    }

    [Test]
    public void ShouldDeserializeLongChatId()
    {
        const string json = "{ \"chat_id\":9223372036854775807}";
        var deserializedJson = JsonConvert.DeserializeObject<ForwardMessage>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.ChatId.Identifier == long.MaxValue, Is.True);
    }

    [Test]
    public void ShouldDeserializeStringChatId()
    {
        const string json = "{ \"chat_id\":\"@chatId\"}";
        var deserializedJson = JsonConvert.DeserializeObject<ForwardMessage>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.ChatId.Username.Equals("@chatId"), Is.True);
    }

    [Test]
    public void ShouldSerializeIntChatId()
    {
        ChatId chatId = int.MaxValue;
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains($"{int.MaxValue}"), Is.True);
    }

    [Test]
    public void ShouldSerializeLongChatId()
    {
        ChatId chatId = long.MaxValue;
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains($"{long.MaxValue}"), Is.True);
    }

    [Test]
    public void ShouldSerializeStringChatId()
    {
        ChatId chatId = "@chatId";
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.That(json, Is.Not.Null);
        Assert.That(json.Contains("\"@chatId\""), Is.True);
    }
}
