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

    public IObservable<ChatMemberUpdated> MyChatMember => _myChatMember;

    public IObservable<ChatMemberUpdated> ChatMember => _chatMember;

    public IObservable<ChatJoinRequest> ChatJoinRequest => _chatJoinRequest;

    public IObservable<ChatBoostUpdated> ChatBoost => _chatBoostUpdated;

    public IObservable<ChatBoostRemoved> RemovedChatBoost => _chatBoostRemoved;


    private readonly IDictionary<UpdateTypeWrapper<UpdateType?>, List<object>> _observerDictionary;
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
    private readonly Observable<ChatMemberUpdated> _myChatMember;
    private readonly Observable<ChatMemberUpdated> _chatMember;
    private readonly Observable<ChatJoinRequest> _chatJoinRequest;
    private readonly Observable<ChatBoostUpdated> _chatBoostUpdated;
    private readonly Observable<ChatBoostRemoved> _chatBoostRemoved;

    private readonly ITelegramBot _telegramBot;
    private const int NotRunning = 0;
    private const int Running = 1;
    private int _isRunning = NotRunning;
    private CancellationTokenSource _cancellationTokenSource;

    private bool AnyObserver => _observerDictionary.Any(x => x.Value.Any());

    internal IEnumerable<UpdateType?> UpdateTypes => _observerDictionary.Where(x => x.Value.Any())
                                                                        .Select(x => x.Key.Value);

    public UpdateManager(ITelegramBot telegramBot)
    {
        _telegramBot = telegramBot;
        _observerDictionary = Enum.GetValues(typeof(UpdateType))
                                  .Cast<UpdateType>()
                                  .Select(x => new UpdateTypeWrapper<UpdateType?>(x))
                                  // add any update type
                                  .Append(UpdateTypeWrapper<UpdateType?>.Any())
                                  .ToDictionary(updateType => new UpdateTypeWrapper<UpdateType?>(updateType), _ => new List<object>());
        _chatBoostUpdated = new Observable<ChatBoostUpdated>(UpdateType.ChatBoost, this);
        _chatBoostRemoved = new Observable<ChatBoostRemoved>(UpdateType.RemovedChatBoost, this);
        _chatJoinRequest = new Observable<ChatJoinRequest>(UpdateType.ChatJoinRequest, this);
        _chatMember = new Observable<ChatMemberUpdated>(UpdateType.ChatMember, this);
        _myChatMember = new Observable<ChatMemberUpdated>(UpdateType.MyChatMember, this);
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

                                    // if there is a null value in the list, it means that all updates are allowed
                                    AllowedUpdates = UpdateTypes.Contains(null!)
                                                         ? null
                                                         : UpdateTypes.Where(x => x.HasValue)
                                                                      .Select(x => x.Value)
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

        var updateStrategies = new List<Action<Update>>
                               {
                                   update => OnNext(UpdateType.PreCheckoutQuery, update.PreCheckoutQuery),
                                   update => OnNext(UpdateType.PurchasedPaidMedia, update.PurchasedPaidMedia),
                                   update => OnNext(UpdateType.ShippingQuery, update.ShippingQuery),
                                   update => OnNext(UpdateType.EditedChannelPost, update.EditedChannelPost),
                                   update => OnNext(UpdateType.ChannelPost, update.ChannelPost),
                                   update => OnNext(UpdateType.CallbackQuery, update.CallbackQuery),
                                   update => OnNext(UpdateType.Poll, update.Poll),
                                   update => OnNext(UpdateType.PollAnswer, update.PollAnswer),
                                   update => OnNext(UpdateType.ChosenInlineResult, update.ChosenInlineResult),
                                   update => OnNext(UpdateType.InlineQuery, update.InlineQuery),
                                   update => OnNext(UpdateType.EditedMessage, update.EditedMessage),
                                   update => OnNext(UpdateType.Message, update.Message),
                               };

        foreach (var update in updates)
        {
            OnNext(null, update);

            foreach (var func in updateStrategies)
            {
                func(update);
            }
        }
    }

    internal void OnNext<T>(UpdateType? updateType, T updateMessage)
    {
        if (updateMessage == null)
        {
            return;
        }

        var observers = GetObservers(updateType);
        if (!observers.Any())
        {
            return;
        }

        foreach (var observerObject in observers)
        {
            if (observerObject is not IObserver<T> observer)
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
                methodInfo.Invoke(observer, new object[] { exception });
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    internal List<object> GetObservers(UpdateType? updateType)
    {
        UpdateTypeWrapper<UpdateType?> c;
        if (updateType == null)
        {
            c = UpdateTypeWrapper<UpdateType?>.Any();
        }
        else
        {
            c = updateType;
        }

        _observerDictionary.TryGetValue(c, out var list);
        return list;
    }

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

        if (!AnyObserver &&
            Volatile.Read(ref _isRunning) == Running)
        {
            _cancellationTokenSource?.Cancel();
        }
    }

    private sealed class Observable<T> : IObservable<T>
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

    private sealed class Unsubscriber : IDisposable
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

    public IAsyncEnumerable<ChatMemberUpdated> MyChatMemberEnumerable() => _myChatMember.ToAsyncEnumerable();

    public IAsyncEnumerable<ChatMemberUpdated> ChatMemberEnumerable() => _chatMember.ToAsyncEnumerable();

    public IAsyncEnumerable<ChatJoinRequest> ChatJoinRequestEnumerable() => _chatJoinRequest.ToAsyncEnumerable();

    public IAsyncEnumerable<ChatBoostUpdated> ChatBoostEnumerable() => _chatBoostUpdated.ToAsyncEnumerable();

    public IAsyncEnumerable<ChatBoostRemoved> RemovedChatBoostEnumerable() => _chatBoostRemoved.ToAsyncEnumerable();
#endif

    private struct UpdateTypeWrapper<T>
    {
        private readonly bool _anyType = true;

        private UpdateTypeWrapper(T value, bool anyType) : this()
        {
            _anyType = anyType;
            Value = value;
        }

        public UpdateTypeWrapper(T value) : this(value, value == null)
        {
        }

        private UpdateTypeWrapper(bool anyType) : this(default, anyType)
        {
        }

        public static UpdateTypeWrapper<T> Any() => new(true);

        public T Value { get; }

        public bool IsAny() => _anyType;

        public static implicit operator T(UpdateTypeWrapper<T> updateTypeWrapper) => updateTypeWrapper.Value;

        public static implicit operator UpdateTypeWrapper<T>(T item) => new(item);

        public override string ToString() => Value != null ? Value.ToString() : "Any";

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return IsAny();
            }

            if (obj is not UpdateTypeWrapper<T> no)
            {
                return false;
            }

            if (IsAny())
            {
                return no.IsAny();
            }

            return !no.IsAny() && Value.Equals(no.Value);
        }

        public override int GetHashCode()
        {
            if (_anyType)
            {
                return 0;
            }

            var result = Value.GetHashCode();

            if (result >= 0)
            {
                result++;
            }

            return result;
        }
    }
}
