using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class ChatBoostTest
{

    [Test]
    public async Task TestDeserialize_Premium()
    {
        const string user = "{'id':123,'is_bot':false,'first_name':'Test'}";
        const string boost = "{'boost_id':'abc','add_date':123,'expiration_date':321, 'source': {'source':'premium', 'user': " + user + "}}";
        var stringContent = new StringContent("{'ok':true,'result':{'boosts':[" + boost + "]}");
        var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = stringContent };

        var userChatBoosts = await Task.FromResult(response)
                       .ParseResponse<UserChatBoosts>();
        Assert.That(userChatBoosts, Is.Not.Null);
        Assert.That(userChatBoosts.Boosts, Has.Count.EqualTo(1));
        Assert.That(userChatBoosts.Boosts[0].BoostId, Is.EqualTo("abc"));
        Assert.That(userChatBoosts.Boosts[0].AddDate, Is.EqualTo(123));
        Assert.That(userChatBoosts.Boosts[0].ExpirationDate, Is.EqualTo(321));
        Assert.That(userChatBoosts.Boosts[0].Source.Source, Is.EqualTo(ChatBoostSourceType.Premium));
    }
}
