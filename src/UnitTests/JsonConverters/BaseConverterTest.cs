using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Api;

namespace RxTelegram.Bot.UnitTests.JsonConverters
{
    public class BaseConverterTest
    {
        protected JsonSerializerSettings JsonSerializerSettings;

        [OneTimeSetUp]
        public void Setup() => JsonSerializerSettings = BaseTelegramBot.JsonSerializerSettings;
    }
}
