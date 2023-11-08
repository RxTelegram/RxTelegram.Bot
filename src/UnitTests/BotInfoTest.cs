using NUnit.Framework;
using RxTelegram.Bot.Exceptions;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class BotInfoTest
{
    [Test]
    public void ValidToken()
    {
        var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
        Assert.IsNotNull(botInfo);
        Assert.That(botInfo.Id, Is.EqualTo(123456));
        Assert.That(botInfo.Token, Is.EqualTo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11"));
        Assert.That(botInfo.BotUrl, Is.EqualTo("https://api.telegram.org/bot123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11/"));
        Assert.That(botInfo.BotFileUrl, Is.EqualTo("https://api.telegram.org/file/bot123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11/"));
    }

    [Test]
    [TestCase("a123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11")]
    [TestCase("123456:?????")]
    public void InvalidToken(string token) =>
        Assert.Throws<InvalidTokenException>(() => { new BotInfo(token); });
}
