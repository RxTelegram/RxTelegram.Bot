using System;
using System.Linq;
using NUnit.Framework;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.UnitTests
{
    [TestFixture]
    public class UpdateManagerTest
    {

        [Test]
        public void TestGetUpdateTypes()
        {
            var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
            var telegram = new TelegramApi(botInfo);
            var updateManager = new UpdateManager(telegram);
            updateManager.Message.Subscribe();
            updateManager.EditedChannelPost.Subscribe();
            var types = updateManager.GetUpdateTypes()
                                     .ToList();
            Assert.That(types.Count , Is.EqualTo(2));
            CollectionAssert.Contains(types, UpdateType.Message);
            CollectionAssert.Contains(types, UpdateType.EditedChannelPost);
        }
    }
}
