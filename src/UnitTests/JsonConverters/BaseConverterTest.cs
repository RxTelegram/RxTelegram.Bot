using Newtonsoft.Json;
using RxTelegram.Bot.Api;

namespace RxTelegram.Bot.UnitTests.JsonConverters;

public class BaseConverterTest
{
    protected readonly JsonSerializerSettings JsonSerializerSettings = BaseTelegramBot.JsonSerializerSettings;
}
