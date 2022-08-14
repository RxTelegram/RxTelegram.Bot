using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Passport.Enum;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Enums;

namespace RxTelegram.Bot.UnitTests.JsonConverters
{
    [TestFixture]
    public class StringEnumConverterTest : BaseConverterTest
    {
        [Test]
        public void SerializeElementType()
        {
            var objectToSerialize = new
                                    {
                                        elementType = ElementType.BankStatement
                                    };

            var json = JsonConvert.SerializeObject(objectToSerialize);
            Assert.NotNull(json);
            Assert.True(json.Contains("bank_statement"));
        }

        [Test]
        public void SerializeParseMode()
        {
            var objectToSerialize = new
                                    {
                                        parse = ParseMode.Markdown
                                    };

            var json = JsonConvert.SerializeObject(objectToSerialize);
            Assert.NotNull(json);
            Assert.True(json.Contains("markdown"));
        }

        [Test]
        public void SerializeStickerType()
        {
            var sicker = new Sticker
                         {
                             Type = StickerType.CustomEmoji
                         };
            var json = JsonConvert.SerializeObject(sicker);
            Assert.NotNull(json);
            Assert.True(json.Contains("custom_emoji"));
        }
    }
}
