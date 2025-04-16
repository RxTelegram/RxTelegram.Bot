using System;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.Setup;

namespace RxTelegram.Bot;

public partial class TelegramBot
{
    public class Builder
    {
        private string _token;
        private IObservable<Update> _tracker;
        private IUpdateManager _updateManager;
        public Builder() { }
        public Builder(string token) : this() { _token = token; }

        public Builder SetToken(string token)
        {
            _token = token;
            return this;
        }
        public Builder SetTracker(IObservable<Update> tracker)
        {
            _tracker = tracker;
            return this;
        }
        public Builder SetManager(IUpdateManager updateManager)
        {
            _updateManager = updateManager;
            return this;
        }
        public TelegramBot Build()
        {
            var bot = new TelegramBot(_token);
            _tracker ??= new LongPollingUpdateTracker(bot);
            bot.Updates = _updateManager ?? new UpdateDistributor(_tracker);
            bot.Updates.Set(_tracker);

            return bot;
        }
    }
}
