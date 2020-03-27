using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RxTelegram.Bot.Api;

namespace RxTelegram.Bot.UnitTests
{
    [TestFixture]
    public class UpdateManagerTest
    {

        [Test]
        public void TestGetUpdateTypes()
        {
            var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
            var updateManager = new UpdateManager(botInfo);
            updateManager.Message.Subscribe();
            updateManager.EditedChannelPost.Subscribe();
            var types = updateManager.GetUpdateTypes();
            Assert.That(types.Count , Is.EqualTo(2));
            CollectionAssert.Contains(types, "message");
            CollectionAssert.Contains(types, "edited_channel_post");
        }
    }
}
