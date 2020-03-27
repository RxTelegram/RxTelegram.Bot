using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Reactive;

namespace RxTelegram.Bot.Api
{
    public class UpdateManager : TelegramApi, IUpdateManager
    {
        private readonly Observable<Update> _update = new Observable<Update>();
        private readonly Observable<Message> _message = new Observable<Message>();
        private readonly Observable<Message> _editedMessage = new Observable<Message>();
        private readonly Observable<InlineQuery> _inlineQuery = new Observable<InlineQuery>();
        private readonly Observable<ChosenInlineResult> _chosenInlineResult = new Observable<ChosenInlineResult>();
        private readonly Observable<PollAnswer> _pollAnswer = new Observable<PollAnswer>();
        private readonly Observable<Poll> _poll = new Observable<Poll>();
        private readonly Observable<CallbackQuery> _callbackQuery = new Observable<CallbackQuery>();
        private readonly Observable<Message> _channelPost = new Observable<Message>();
        private readonly Observable<Message> _editedChannelPost = new Observable<Message>();
        private readonly Observable<ShippingQuery> _shippingQuery = new Observable<ShippingQuery>();
        private readonly Observable<PreCheckoutQuery> _preCheckoutQuery = new Observable<PreCheckoutQuery>();
        private readonly SnakeCaseNamingStrategy _snakeCaseNamingStrategy = new SnakeCaseNamingStrategy();
        private bool _isRunning;

        public IObservable<Update> Update => _update;

        public IObservable<Message> Message => _message;

        public IObservable<Message> EditedMessage => _editedMessage;

        public IObservable<InlineQuery> InlineQuery => _inlineQuery;

        public IObservable<ChosenInlineResult> ChosenInlineResult => _chosenInlineResult;

        public IObservable<CallbackQuery> CallbackQuery => _callbackQuery;

        public IObservable<Message> ChannelPost => _channelPost;

        public IObservable<Message> EditedChannelPost => _editedChannelPost;

        public IObservable<ShippingQuery> ShippingQuery => _shippingQuery;

        public IObservable<PreCheckoutQuery> PreCheckoutQuery => _preCheckoutQuery;

        public IObservable<Poll> Poll => _poll;

        public IObservable<PollAnswer> PollAnswer => _pollAnswer;

        public UpdateManager(BotInfo botInfo) : base(botInfo)
        {
            RegisterEvents(_update);
            RegisterEvents(_message);
            RegisterEvents(_editedMessage);
            RegisterEvents(_inlineQuery);
            RegisterEvents(_chosenInlineResult);
            RegisterEvents(_pollAnswer);
            RegisterEvents(_poll);
            RegisterEvents(_callbackQuery);
            RegisterEvents(_channelPost);
            RegisterEvents(_editedChannelPost);
            RegisterEvents(_shippingQuery);
            RegisterEvents(_preCheckoutQuery);
        }

        private void RegisterEvents<T>(Observable<T> observable)
        {
            observable.AddObserver += OnAddObserver;
            observable.RemoveObserver += OnRemoveObservere;
        }

        private void OnRemoveObservere(object sender, EventArgs e)
        {
            if (AnyObserver() == false)
            {
                // stop all
            }
        }

        private void OnAddObserver(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                // todo update allowed_updates
                return;
            }

            _isRunning = true;
            Task.Run(RunUpdate);
        }

        private async Task RunUpdate()
        {
            int? offset = null;
            try
            {
                while (AnyObserver())
                {
                    var payload = new
                                  {
                                      offset,
                                      timeout = 10,
                                      allowed_updates = GetUpdateTypes()
                                  };
                    var result = await Get<Update[]>("getUpdates", payload);
                    if (!result.Any())
                    {
                        await Task.Delay(1000);
                        continue;
                    }

                    offset = result.Max(x => x.UpdateId) + 1;
                    foreach (var update in result)
                    {
                        if (update.Message != null)
                        {
                            _message.OnNext(update.Message);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _update.OnException(exception);
                _message.OnException(exception);
                _editedMessage.OnException(exception);
                _inlineQuery.OnException(exception);
                _chosenInlineResult.OnException(exception);
                _pollAnswer.OnException(exception);
                _poll.OnException(exception);
                _callbackQuery.OnException(exception);
                _channelPost.OnException(exception);
                _editedChannelPost.OnException(exception);
                _shippingQuery.OnException(exception);
                _preCheckoutQuery.OnException(exception);
            }

            _isRunning = false;
        }

        private bool AnyObserver() => _callbackQuery.HasObserver ||
                                      _channelPost.HasObserver ||
                                      _chosenInlineResult.HasObserver ||
                                      _editedChannelPost.HasObserver ||
                                      _editedMessage.HasObserver ||
                                      _editedMessage.HasObserver ||
                                      _inlineQuery.HasObserver ||
                                      _message.HasObserver ||
                                      _poll.HasObserver ||
                                      _pollAnswer.HasObserver ||
                                      _preCheckoutQuery.HasObserver ||
                                      _shippingQuery.HasObserver ||
                                      _update.HasObserver;

        public List<string> GetUpdateTypes()
        {
            var list = new List<UpdateType>();
            if (_update.HasObserver)
            {
                return null;
            }

            if (_message.HasObserver)
            {
                list.Add(UpdateType.Message);
            }

            if (_editedMessage.HasObserver)
            {
                list.Add(UpdateType.EditedMessage);
            }

            if (_editedMessage.HasObserver)
            {
                list.Add(UpdateType.EditedMessage);
            }

            if (_inlineQuery.HasObserver)
            {
                list.Add(UpdateType.InlineQuery);
            }

            if (_chosenInlineResult.HasObserver)
            {
                list.Add(UpdateType.ChosenInlineResult);
            }

            if (_pollAnswer.HasObserver)
            {
                list.Add(UpdateType.PollAnswer);
            }

            if (_poll.HasObserver)
            {
                list.Add(UpdateType.Poll);
            }

            if (_callbackQuery.HasObserver)
            {
                list.Add(UpdateType.CallbackQuery);
            }

            if (_channelPost.HasObserver)
            {
                list.Add(UpdateType.ChannelPost);
            }

            if (_editedChannelPost.HasObserver)
            {
                list.Add(UpdateType.EditedChannelPost);
            }

            if (_shippingQuery.HasObserver)
            {
                list.Add(UpdateType.ShippingQuery);
            }

            if (_preCheckoutQuery.HasObserver)
            {
                list.Add(UpdateType.PreCheckoutQuery);
            }

            return list.Select(x => _snakeCaseNamingStrategy.GetPropertyName(x.ToString(), false))
                       .ToList();
        }
    }
}
