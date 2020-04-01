using System;
using System.Linq;
using NUnit.Framework;
using RxTelegram.Bot.Interface.Stickers.Requests;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.UnitTests
{
    [TestFixture]
    public class ValidationTest
    {
        [Test]
        public void ValidationErrorStringAttributePresentTest()
        {
            var type = typeof(ValidationErrors);
            foreach (var value in Enum.GetValues(type))
            {
                var memInfo = type.GetMember(value.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(ValidationErrorsStringAttribute), false);
                Assert.IsNotNull(attributes.FirstOrDefault());
            }
        }

        [Test]
        public void Test ()
        {
            var obj = new CreateNewStickerSet();
            obj.IsValid();
            Assert.That(obj.Errors.Count, Is.EqualTo(5));
        }

    }
}
