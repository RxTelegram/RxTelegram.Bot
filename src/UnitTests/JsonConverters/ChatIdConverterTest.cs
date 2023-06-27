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
        Assert.NotNull(deserializedJson);
        Assert.True(deserializedJson.ChatId.Identifier == int.MaxValue);
    }

    [Test]
    public void ShouldDeserializeLongChatId()
    {
        const string json = "{ \"chat_id\":9223372036854775807}";
        var deserializedJson = JsonConvert.DeserializeObject<ForwardMessage>(json, JsonSerializerSettings);
        Assert.NotNull(deserializedJson);
        Assert.True(deserializedJson.ChatId.Identifier == long.MaxValue);
    }

    [Test]
    public void ShouldDeserializeStringChatId()
    {
        const string json = "{ \"chat_id\":\"@chatId\"}";
        var deserializedJson = JsonConvert.DeserializeObject<ForwardMessage>(json, JsonSerializerSettings);
        Assert.NotNull(deserializedJson);
        Assert.True(deserializedJson.ChatId.Username.Equals("@chatId"));
    }

    [Test]
    public void ShouldSerializeIntChatId()
    {
        ChatId chatId = int.MaxValue;
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.NotNull(json);
        Assert.True(json.Contains($"{int.MaxValue}"));
    }

    [Test]
    public void ShouldSerializeLongChatId()
    {
        ChatId chatId = long.MaxValue;
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.NotNull(json);
        Assert.True(json.Contains($"{long.MaxValue}"));
    }

    [Test]
    public void ShouldSerializeStringChatId()
    {
        ChatId chatId = "@chatId";
        var json = JsonConvert.SerializeObject(chatId, JsonSerializerSettings);
        Assert.NotNull(json);
        Assert.True(json.Contains("\"@chatId\""));
    }
}
