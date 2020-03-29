using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var prop = typeof(UpdateManager).GetProperty("GetUpdateTypes", BindingFlags.NonPublic | BindingFlags.Instance);
            if (prop == null)
                throw new Exception("Property not found!");
            var getter = prop.GetGetMethod(nonPublic: true);
            var objectList = getter.Invoke(updateManager, null);
            if (!(objectList is IEnumerable<UpdateType> updateTypesList))
                throw new Exception("Property cast not possible!");
            var updateTypes = updateTypesList.ToList();
            Assert.That(updateTypes.Count, Is.EqualTo(2));
            CollectionAssert.Contains(updateTypes, UpdateType.Message);
            CollectionAssert.Contains(updateTypes, UpdateType.EditedChannelPost);
            return;
        }
    }
}
