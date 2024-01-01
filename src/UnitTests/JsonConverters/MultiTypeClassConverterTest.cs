using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Utils;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

[TestFixture]
public class MultiTypeClassConverterTest : BaseConverterTest
{
    private const string User = "{\"id\":123,\"is_bot\":false,\"first_name\":\"Test\"}";

    [Test]
    public async Task ShouldDeserializeHttpResponse()
    {
        const string boost =
            "{\"boost_id\":\"abc\",\"add_date\":123,\"expiration_date\":321, \"source\": {\"source\":\"premium\", \"user\": " + User + "}}";
        const string content = "{\"ok\":true,\"result\":{\"boosts\":[" + boost + "]}}";
        var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content) };

        var userChatBoosts = await Task.FromResult(response)
                                       .ParseResponse<UserChatBoosts>();
        Assert.That(userChatBoosts, Is.Not.Null);
        Assert.That(userChatBoosts.Boosts, Has.Count.EqualTo(1));
        Assert.That(userChatBoosts.Boosts[0].BoostId, Is.EqualTo("abc"));
        Assert.That(userChatBoosts.Boosts[0].AddDate, Is.EqualTo(DateTime.Parse("1970-01-01 00:02:03")));
        Assert.That(userChatBoosts.Boosts[0].ExpirationDate, Is.EqualTo(DateTime.Parse("1970-01-01 00:05:21")));
        Assert.That(userChatBoosts.Boosts[0].Source.Source, Is.EqualTo(ChatBoostSourceType.Premium));
        Assert.That(userChatBoosts.Boosts[0].Source, Is.TypeOf<ChatBoostSourcePremium>());
    }

    [Test]
    public void ShouldDeserializePremium()
    {
        const string json =
            "{\"boost_id\":\"abc\",\"add_date\":123,\"expiration_date\":321, \"source\": {\"source\":\"premium\", \"user\": " + User + "}}";
        var deserializedJson = JsonConvert.DeserializeObject<ChatBoost>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.Source.Source, Is.EqualTo(ChatBoostSourceType.Premium));
        Assert.That(deserializedJson.Source, Is.TypeOf<ChatBoostSourcePremium>());
    }

    [Test]
    public void ShouldDeserializeGiftCode()
    {
        const string json =
            "{\"boost_id\":\"abc\",\"add_date\":123,\"expiration_date\":321, \"source\": {\"source\":\"gift_code\", \"user\": " +
            User +
            "}}";
        var deserializedJson = JsonConvert.DeserializeObject<ChatBoost>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.Source.Source, Is.EqualTo(ChatBoostSourceType.GiftCode));
        Assert.That(deserializedJson.Source, Is.TypeOf<ChatBoostSourceGiftCode>());
    }

    [Test]
    public void ShouldDeserializeGiveaway()
    {
        const string json =
            "{\"boost_id\":\"abc\",\"add_date\":123,\"expiration_date\":321, \"source\": {\"source\":\"giveaway\", \"giveaway_message_id\": 123}}";
        var deserializedJson = JsonConvert.DeserializeObject<ChatBoost>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.Source.Source, Is.EqualTo(ChatBoostSourceType.Giveaway));
        Assert.That(deserializedJson.Source, Is.TypeOf<ChatBoostSourceGiveaway>());
    }

    [Test]
    public void ShouldDeserializeExternalReplyInfo()
    {
        const string messageOriginUserJson = "{\"type\":\"user\",\"date\":123,\"sender_user\":" + User + "}";
        const string json = "{\"origin\":" + messageOriginUserJson + "}";
        var deserializedJson = JsonConvert.DeserializeObject<ExternalReplyInfo>(json, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
        Assert.That(deserializedJson.Origin.Type, Is.EqualTo(MessageOriginType.User));
        Assert.That(deserializedJson.Origin, Is.TypeOf<MessageOriginUser>());
        var user = (MessageOriginUser)deserializedJson.Origin;
        Assert.That(user.SenderUser.Id, Is.EqualTo(123));
    }

    [Test]
    public void ShouldDeserializeUpdateMessage()
    {
        const string response =
            """
            {\n \"update_id\": 123,\n \"message\": {\n \"message_id\": 1,\n \"from\": {\n \"id\": 1,\n \"is_bot\": false,\n
            \"first_name\": \"Rx\",\n \"last_name\": \"Telegram\",\n \"username\": \"RxTelegram\",\n \"language_code\":
            \"en\"\n },\n \"chat\": {\n \"id\": 1,\n \"first_name\": \"Rx\",\n \"last_name\": \"Telegram\",\n \"username\":
            \"RxTelegram\",\n \"type\": \"private\"\n },\n \"date\": 1704136224,\n \"forward_origin\": {\n \"type\": \"user\",\n
            \"sender_user\": {\n \"id\": 1,\n \"is_bot\": false,\n \"first_name\": \"Dev\",\n \"last_name\": \"Eloper\"\n },\n
            \"date\": 1704135815\n },\n \"forward_from\": {\n \"id\": 1,\n \"is_bot\": false,\n \"first_name\": \"Dev\",\n
            \"last_name\": \"Eloper\"\n },\n \"forward_date\": 1704135815,\n \"text\": \"This is a scam!\"\n }\n}\n
            """;
        var deserializedJson = JsonConvert.DeserializeObject<Update>(response, JsonSerializerSettings);
        Assert.That(deserializedJson, Is.Not.Null);
    }
}
