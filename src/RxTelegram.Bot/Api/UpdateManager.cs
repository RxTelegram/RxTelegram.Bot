using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;

namespace RxTelegram.Bot.Api
{
    public class UpdateManager : IUpdateManager
    {
        private readonly IDictionary<UpdateType, List<object>> _observerDictionary;
        private readonly List<object> _updateObservers;
        private readonly Observable<Update> _update;
        private readonly Observable<Message> _message;
        private readonly Observable<Message> _editedMessage;
        private readonly Observable<InlineQuery> _inlineQuery;
        private readonly Observable<ChosenInlineResult> _chosenInlineResult;
        private readonly Observable<PollAnswer> _pollAnswer;
        private readonly Observable<Poll> _poll;
        private readonly Observable<CallbackQuery> _callbackQuery;
        private readonly Observable<Message> _channelPost;
        private readonly Observable<Message> _editedChannelPost;
        private readonly Observable<ShippingQuery> _shippingQuery;
        private readonly Observable<PreCheckoutQuery> _preCheckoutQuery;
        private bool _isRunning;
        private readonly TelegramApi _telegramApi;

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

        private bool AnyObserver => _observerDictionary.Any(x => x.Value.Any()) || _updateObservers.Any();

        private IEnumerable<UpdateType> GetUpdateTypes => _observerDictionary.Where(x => x.Value.Any())
                                                                             .Select(x => x.Key);

        public UpdateManager(TelegramApi telegramApi)
        {
            _telegramApi = telegramApi;
            _updateObservers = new List<object>();
            _observerDictionary = new Dictionary<UpdateType, List<object>>();
            _preCheckoutQuery = new Observable<PreCheckoutQuery>(UpdateType.PreCheckoutQuery, this);
            _shippingQuery = new Observable<ShippingQuery>(UpdateType.ShippingQuery, this);
            _editedChannelPost = new Observable<Message>(UpdateType.EditedChannelPost, this);
            _channelPost = new Observable<Message>(UpdateType.ChannelPost, this);
            _callbackQuery = new Observable<CallbackQuery>(UpdateType.CallbackQuery, this);
            _poll = new Observable<Poll>(UpdateType.Poll, this);
            _pollAnswer = new Observable<PollAnswer>(UpdateType.PollAnswer, this);
            _chosenInlineResult = new Observable<ChosenInlineResult>(UpdateType.ChosenInlineResult, this);
            _inlineQuery = new Observable<InlineQuery>(UpdateType.InlineQuery, this);
            _editedMessage = new Observable<Message>(UpdateType.EditedMessage, this);
            _message = new Observable<Message>(UpdateType.Message, this);
            _update = new Observable<Update>(null, this);
        }

        private async Task RunUpdate()
        {
            int? offset = null;
            try
            {
                while (AnyObserver)
                {
                    var getUpdate = new GetUpdate
                                    {
                                        Offset = offset,
                                        Timeout = 10,
                                        AllowedUpdates = GetUpdateTypes
                                    };
                    var result = await _telegramApi.GetUpdate(getUpdate);
                    if (!result.Any())
                    {
                        await Task.Delay(1000);
                        continue;
                    }

                    offset = result.Max(x => x.UpdateId) + 1;
                    foreach (var update in result)
                    {
                        OnNext(null, update);
                        if (update.PreCheckoutQuery != null) {
                            OnNext(UpdateType.PreCheckoutQuery, update.PreCheckoutQuery);
                        }
                        if (update.ShippingQuery != null) {
                            OnNext(UpdateType.ShippingQuery, update.ShippingQuery);
                        }
                        if (update.EditedChannelPost != null) {
                            OnNext(UpdateType.EditedChannelPost, update.EditedChannelPost);
                        }
                        if (update.ChannelPost != null) {
                            OnNext(UpdateType.ChannelPost, update.ChannelPost);
                        }
                        if (update.CallbackQuery != null) {
                            OnNext(UpdateType.CallbackQuery, update.CallbackQuery);
                        }
                        if (update.Poll != null) {
                            OnNext(UpdateType.Poll, update.Poll);
                        }
                        if (update.PollAnswer != null) {
                            OnNext(UpdateType.PollAnswer, update.PollAnswer);
                        }
                        if (update.ChosenInlineResult != null) {
                            OnNext(UpdateType.ChosenInlineResult, update.ChosenInlineResult);
                        }
                        if (update.InlineQuery != null) {
                            OnNext(UpdateType.InlineQuery, update.InlineQuery);
                        }
                        if (update.EditedMessage != null) {
                            OnNext(UpdateType.EditedMessage, update.EditedMessage);
                        }
                        if (update.Message != null) {
                            OnNext(UpdateType.Message, update.Message);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OnException(exception);
            }

            _isRunning = false;
        }

        private void OnNext<T>(UpdateType? updateType, T updateMessage)
        {
            var observers = GetObservers(updateType);
            if (!observers.Any())
            {
                return;
            }

            foreach (var observerObject in observers)
            {
                if (!(observerObject is IObserver<T> observer))
                {
                    continue;
                }

                try
                {
                    observer.OnNext(updateMessage);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private void OnException(Exception exception)
        {
            if (!AnyObserver)
            {
                return;
            }

            foreach (var observer in _observerDictionary.Values.SelectMany(x => x)
                                                        .ToList())
            {
                var observerType = observer.GetType();
                if (observerType.GetInterfaces()
                                .Contains(typeof(IObserver<>)))
                {
                    continue;
                }

                const string onErrorName = nameof(IObserver<object>.OnError);
                var methodInfo = observerType.GetMethod(onErrorName);
                if (methodInfo == null)
                {
                    // observer without onerror function should never happened
                    continue;
                }

                try
                {
                    methodInfo.Invoke(observer, new object[] {exception});
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private List<object> GetObservers(UpdateType? updateType)
        {
            if (!updateType.HasValue)
            {
                return _updateObservers;
            }

            if (!_observerDictionary.ContainsKey(updateType.Value))
            {
                _observerDictionary.Add(updateType.Value, new List<object>());
            }

            return _observerDictionary[updateType.Value];
        }

        private IDisposable Subscribe<T>(UpdateType? updateType, IObserver<T> observer)
        {
            var observers = GetObservers(updateType);
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            if (!_isRunning)
            {
                _isRunning = true;
                Task.Run(RunUpdate);
            }
            else
            {
                // todo update allowed_updates
            }

            return new Unsubscriber(() => Remove(updateType, observer));
        }

        private void Remove<T>(UpdateType? updateType, IObserver<T> observer)
        {
            var observers = GetObservers(updateType);
            if (!observers.Contains(observer))
            {
                return;
            }

            observers.Remove(observer);

            if (AnyObserver == false)
            {
                // cancel current requests
            }
        }

        private class Observable<T> : IObservable<T>
        {
            private readonly UpdateManager _updateManager;
            private readonly UpdateType? _updateType;

            public Observable(UpdateType? updateType, UpdateManager updateManager)
            {
                _updateType = updateType;
                _updateManager = updateManager;
            }

            public IDisposable Subscribe(IObserver<T> observer) => _updateManager.Subscribe(_updateType, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly Action _dispose;

            public Unsubscriber(Action action) => _dispose = action;

            public void Dispose() => _dispose?.Invoke();
        }
    }
}
