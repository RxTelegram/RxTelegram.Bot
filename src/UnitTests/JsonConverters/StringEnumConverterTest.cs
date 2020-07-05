using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Passport.Enum;

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
    }
}
