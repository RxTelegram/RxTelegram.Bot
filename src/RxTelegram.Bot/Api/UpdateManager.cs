using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Reactive;

namespace RxTelegram.Bot.Api
{
    public class UpdateManager : IUpdateManager
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

        private TelegramApi TelegramApi { get; }

        public UpdateManager(TelegramApi telegramApi)
        {
            _update.CollectionChanged += CollectionChanged;
            _message.CollectionChanged += CollectionChanged;
            _editedMessage.CollectionChanged += CollectionChanged;
            _inlineQuery.CollectionChanged += CollectionChanged;
            _chosenInlineResult.CollectionChanged += CollectionChanged;
            _pollAnswer.CollectionChanged += CollectionChanged;
            _poll.CollectionChanged += CollectionChanged;
            _callbackQuery.CollectionChanged += CollectionChanged;
            _channelPost.CollectionChanged += CollectionChanged;
            _editedChannelPost.CollectionChanged += CollectionChanged;
            _shippingQuery.CollectionChanged += CollectionChanged;
            _preCheckoutQuery.CollectionChanged += CollectionChanged;
            TelegramApi = telegramApi;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (_isRunning)
                    {
                        // todo update allowed_updates
                        return;
                    }

                    _isRunning = true;
                    Task.Run(RunUpdate);
                    break;
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    if (AnyObserver() == false)
                    {
                        // stop all
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                case NotifyCollectionChangedAction.Replace:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task RunUpdate()
        {
            int? offset = null;
            try
            {
                while (AnyObserver())
                {
                    var getUpdate = new GetUpdate
                                    {
                                        Offset = offset,
                                        Timeout = 10,
                                        AllowedUpdates = GetUpdateTypes()
                                    };
                    var result = await TelegramApi.GetUpdate(getUpdate);
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

        public IEnumerable<UpdateType> GetUpdateTypes()
        {
            if (_update.HasObserver)
            {
                yield break;
            }

            if (_message.HasObserver)
            {
                yield return UpdateType.Message;
            }

            if (_editedMessage.HasObserver)
            {
                yield return UpdateType.EditedMessage;
            }

            if (_editedMessage.HasObserver)
            {
                yield return UpdateType.EditedMessage;
            }

            if (_inlineQuery.HasObserver)
            {
                yield return UpdateType.InlineQuery;
            }

            if (_chosenInlineResult.HasObserver)
            {
                yield return UpdateType.ChosenInlineResult;
            }

            if (_pollAnswer.HasObserver)
            {
                yield return UpdateType.PollAnswer;
            }

            if (_poll.HasObserver)
            {
                yield return UpdateType.Poll;
            }

            if (_callbackQuery.HasObserver)
            {
                yield return UpdateType.CallbackQuery;
            }

            if (_channelPost.HasObserver)
            {
                yield return UpdateType.ChannelPost;
            }

            if (_editedChannelPost.HasObserver)
            {
                yield return UpdateType.EditedChannelPost;
            }

            if (_shippingQuery.HasObserver)
            {
                yield return UpdateType.ShippingQuery;
            }

            if (_preCheckoutQuery.HasObserver)
            {
                yield return UpdateType.PreCheckoutQuery;
            }
        }
    }
}
