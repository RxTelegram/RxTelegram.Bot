using System;
using System.Reflection;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class ChatIdTest
{
    [Test]
    public void TestString()
    {
        ChatId chatId = "test";
        Assert.That(chatId.Username, Is.EqualTo("test"));
        Assert.Null(chatId.Identifier);
    }

    [Test]
    public void TestLongString()
    {
        ChatId chatId = "-10000";
        Assert.That(chatId.Username, Is.EqualTo("-10000"));
        Assert.Null(chatId.Identifier);
    }

    [Test]
    public void TestLong()
    {
        ChatId chatId = -1000000000000;
        Assert.That(chatId.Identifier, Is.EqualTo(-1000000000000));
        Assert.Null(chatId.Username);
    }

    [Test]
    public void TestInt()
    {
        ChatId chatId = -1;
        Assert.That(chatId.Identifier, Is.EqualTo(-1));
        Assert.Null(chatId.Username);
    }

    [Test]
    public void TestForPrivateConstructor()
    {
        var myType = typeof(ChatId);
        // Get the public instance constructor that takes an integer parameter.
        var constructorInfoObj = myType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, CallingConventions.HasThis,
                                                       Array.Empty<Type>(), null);
        Assert.IsNotNull(constructorInfoObj);
        Assert.That(constructorInfoObj.IsPrivate);
    }
}
