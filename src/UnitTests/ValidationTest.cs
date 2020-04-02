using System;
using System.Linq;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
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
        public void TestInvalid()
        {
            var obj = new CreateNewStickerSet();
            Assert.False(obj.IsValid());
            Assert.That(obj.Errors.Count, Is.EqualTo(5));
            var errors = obj.Errors.Select(x => x.GetMessage).ToList();
            CollectionAssert.Contains(errors, "(PngSticker, TgsSticker): \"One of these properties need to be set\"");
            CollectionAssert.Contains(errors, "(Name): \"Field is not set, but required\"");
            CollectionAssert.Contains(errors, "(Title): \"Field is not set, but required\"");
            CollectionAssert.Contains(errors, "(Emojis): \"Field is not set, but required\"");
            CollectionAssert.Contains(errors, "(Name): \"Stickersets Created by bots need to end with _by_<botname> \"");
        }

        [Test]
        public void TestValid()
        {
            var obj = new CreateNewStickerSet
                      {
                          Emojis = "❤",
                          Name = "StickerSet_by_BlaBot",
                          Title = "Title",
                          PngSticker = new InputFile("Path")
                      };
            Assert.That(obj.IsValid());
            Assert.That(obj.Errors.Count, Is.EqualTo(0));
        }
    }
}
