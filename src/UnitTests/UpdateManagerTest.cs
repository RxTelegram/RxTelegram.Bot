using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class UpdateManagerTest
{
    [Test]
    public void TestGetUpdateTypes()
    {
        var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
        var telegram = new TelegramBot(botInfo);
        var updateManager = new UpdateManager(telegram);
        updateManager.Message.Subscribe();
        updateManager.EditedChannelPost.Subscribe();

        var updateTypes = updateManager.UpdateTypes.ToList();
        Assert.That(updateTypes.Count, Is.EqualTo(2));
        CollectionAssert.Contains(updateTypes, UpdateType.Message);
        CollectionAssert.Contains(updateTypes, UpdateType.EditedChannelPost);
    }
}
