using System;
using System.Reflection;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class ChatIdTest
{
    [Test]
    public void TestString()
    {
        ChatId chatId = "test";
        Assert.That(chatId.Username, Is.EqualTo("test"));
        Assert.That(chatId.Identifier, Is.Null);
    }

    [Test]
    public void TestLongString()
    {
        ChatId chatId = "-10000";
        Assert.That(chatId.Username, Is.EqualTo("-10000"));
        Assert.That(chatId.Identifier, Is.Null);
    }

    [Test]
    public void TestLong()
    {
        ChatId chatId = -1000000000000;
        Assert.That(chatId.Identifier, Is.EqualTo(-1000000000000));
        Assert.That(chatId.Username, Is.Null);
    }

    [Test]
    public void TestInt()
    {
        ChatId chatId = -1;
        Assert.That(chatId.Identifier, Is.EqualTo(-1));
        Assert.That(chatId.Username, Is.Null);
    }

    [Test]
    public void TestForPrivateConstructor()
    {
        var myType = typeof(ChatId);
        // Get the public instance constructor that takes an integer parameter.
        var constructorInfoObj = myType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, CallingConventions.HasThis,
                                                       Array.Empty<Type>(), null);
        Assert.That(constructorInfoObj, Is.Not.Null);
        Assert.That(constructorInfoObj.IsPrivate);
    }
}
