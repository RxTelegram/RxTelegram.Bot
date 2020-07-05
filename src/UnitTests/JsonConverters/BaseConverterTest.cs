using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Api;

namespace RxTelegram.Bot.UnitTests.JsonConverters
{
    public class BaseConverterTest
    {
        [OneTimeSetUp]
        public void Setup() => JsonConvert.DefaultSettings = () => BaseTelegramBot.JsonSerializerSettings;
    }
}
