using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;

#if NETSTANDARD2_1
using RxTelegram.Bot.Utils;
#endif

namespace RxTelegram.Bot.Api;

public class UpdateManager : IUpdateManager
{
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
    private readonly ITelegramBot _telegramBot;
    private const int NotRunning = 0;
    private const int Running = 1;
    private int _isRunning = NotRunning;
    private CancellationTokenSource _cancellationTokenSource;

    private bool AnyObserver => _updateObservers.Any() || _observerDictionary.Any(x => x.Value.Any());

    internal IEnumerable<UpdateType> UpdateTypes => _updateObservers.Any()
                                                        ? _observerDictionary.Select(x => x.Key)
                                                        : _observerDictionary.Where(x => x.Value.Any())
                                                                             .Select(x => x.Key);

    public UpdateManager(ITelegramBot telegramBot)
    {
        _telegramBot = telegramBot;
        _updateObservers = new List<object>();
        _observerDictionary = Enum.GetValues(typeof(UpdateType))
                                  .Cast<UpdateType>()
                                  .ToDictionary(updateType => updateType, updateType => new List<object>());
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

    internal async Task RunUpdateSafe()
    {
        try
        {
            _cancellationTokenSource = new CancellationTokenSource();
            await RunUpdate();
        }
        catch (Exception)
        {
            // ignored
        }
        finally
        {
            Volatile.Write(ref _isRunning, NotRunning);
            _cancellationTokenSource = null;
        }
    }

    internal async Task RunUpdate()
    {
        int? offset = null;

        while (AnyObserver)
        {
            try
            {
                // if the token already canceled before the first request reset token
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource = new CancellationTokenSource();
                }

                var getUpdate = new GetUpdate
                                {
                                    Offset = offset,
                                    Timeout = 60,
                                    AllowedUpdates = UpdateTypes
                                };
                var result = await _telegramBot.GetUpdate(getUpdate, _cancellationTokenSource.Token);
                if (!result.Any())
                {
                    await Task.Delay(1000);
                    continue;
                }

                offset = result.Max(x => x.UpdateId) + 1;
                DistributeUpdates(result);
            }
            catch (TaskCanceledException)
            {
                // create new token and check observers
                offset = null;
                _cancellationTokenSource = new CancellationTokenSource();
            }
            catch (Exception exception)
            {
                // unexpected exception report them to the observers and cancel run update
                OnException(exception);
                throw;
            }
        }
    }

    internal void DistributeUpdates(Update[] updates)
    {
        if (updates?.Any() != true)
        {
            return;
        }

        foreach (var update in updates)
        {
            OnNext(null, update);
            if (update.PreCheckoutQuery != null)
            {
                OnNext(UpdateType.PreCheckoutQuery, update.PreCheckoutQuery);
            }

            if (update.ShippingQuery != null)
            {
                OnNext(UpdateType.ShippingQuery, update.ShippingQuery);
            }

            if (update.EditedChannelPost != null)
            {
                OnNext(UpdateType.EditedChannelPost, update.EditedChannelPost);
            }

            if (update.ChannelPost != null)
            {
                OnNext(UpdateType.ChannelPost, update.ChannelPost);
            }

            if (update.CallbackQuery != null)
            {
                OnNext(UpdateType.CallbackQuery, update.CallbackQuery);
            }

            if (update.Poll != null)
            {
                OnNext(UpdateType.Poll, update.Poll);
            }

            if (update.PollAnswer != null)
            {
                OnNext(UpdateType.PollAnswer, update.PollAnswer);
            }

            if (update.ChosenInlineResult != null)
            {
                OnNext(UpdateType.ChosenInlineResult, update.ChosenInlineResult);
            }

            if (update.InlineQuery != null)
            {
                OnNext(UpdateType.InlineQuery, update.InlineQuery);
            }

            if (update.EditedMessage != null)
            {
                OnNext(UpdateType.EditedMessage, update.EditedMessage);
            }

            if (update.Message != null)
            {
                OnNext(UpdateType.Message, update.Message);
            }
        }
    }

    internal void OnNext<T>(UpdateType? updateType, T updateMessage)
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

    internal void OnException(Exception exception)
    {
        if (!AnyObserver)
        {
            return;
        }

        foreach (var observer in _observerDictionary.Values.SelectMany(x => x)
                                                    .ToList())
        {
            var observerType = observer.GetType();
            if (!observerType.GetInterfaces()
                             .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IObserver<>)))
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

    internal List<object> GetObservers(UpdateType? updateType) =>
        !updateType.HasValue ? _updateObservers : _observerDictionary[updateType.Value];

    internal IDisposable Subscribe<T>(UpdateType? updateType, IObserver<T> observer)
    {
        var observers = GetObservers(updateType);

        int updatesTypes;
        lock (observers)
        {
            updatesTypes = UpdateTypes.Count();

            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        if (Interlocked.Exchange(ref _isRunning, Running) == NotRunning)
        {
            Task.Run(RunUpdateSafe);
        }
        else if (updatesTypes != UpdateTypes.Count())
        {
            // cancel current requests to update types
            _cancellationTokenSource?.Cancel();
        }

        return new Unsubscriber(() => Remove(updateType, observer));
    }

    internal void Remove<T>(UpdateType? updateType, IObserver<T> observer)
    {
        var observers = GetObservers(updateType);
        if (!observers.Contains(observer))
        {
            return;
        }

        lock (observers)
        {
            observers.Remove(observer);
        }

        if (AnyObserver == false &&
            Volatile.Read(ref _isRunning) == Running)
        {
            _cancellationTokenSource?.Cancel();
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

#if NETSTANDARD2_1
    public IAsyncEnumerable<Update> UpdateEnumerable() => _update.ToAsyncEnumerable();

    public IAsyncEnumerable<Message> MessageEnumerable() => _message.ToAsyncEnumerable();

    public IAsyncEnumerable<Message> EditedMessageEnumerable() => _editedMessage.ToAsyncEnumerable();

    public IAsyncEnumerable<InlineQuery> InlineQueryEnumerable() => _inlineQuery.ToAsyncEnumerable();

    public IAsyncEnumerable<ChosenInlineResult> ChosenInlineResultEnumerable() => _chosenInlineResult.ToAsyncEnumerable();

    public IAsyncEnumerable<CallbackQuery> CallbackQueryEnumerable() => _callbackQuery.ToAsyncEnumerable();

    public IAsyncEnumerable<Message> ChannelPostEnumerable() => _channelPost.ToAsyncEnumerable();

    public IAsyncEnumerable<Message> EditedChannelPostEnumerable() => _editedChannelPost.ToAsyncEnumerable();

    public IAsyncEnumerable<ShippingQuery> ShippingQueryEnumerable() => _shippingQuery.ToAsyncEnumerable();

    public IAsyncEnumerable<PreCheckoutQuery> PreCheckoutQueryEnumerable() => _preCheckoutQuery.ToAsyncEnumerable();

    public IAsyncEnumerable<Poll> PollEnumerable() => _poll.ToAsyncEnumerable();

    public IAsyncEnumerable<PollAnswer> PollAnswerEnumerable() => _pollAnswer.ToAsyncEnumerable();
#endif
}
