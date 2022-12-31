using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.UnitTests.JsonConverters
{
    [TestFixture]
    public class InputFileConverterTest : BaseConverterTest
    {
        [Test]
        public void SerializeWithoutMultiPartJsonWriter()
        {
            using var stream = new MemoryStream();
            var inputFile = new InputFile(stream);
            var json = JsonConvert.SerializeObject(inputFile, JsonSerializerSettings);
            Assert.That(json, Is.EqualTo("null"));
        }
    }
}
