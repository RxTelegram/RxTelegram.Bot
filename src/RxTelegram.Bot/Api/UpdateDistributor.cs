using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Utils.Rx;
using System;
using System.Collections.Generic;
using System.Linq;

#if NETSTANDARD2_1

using RxTelegram.Bot.Utils;

#endif

namespace RxTelegram.Bot.Api;

public sealed class UpdateDistributor : IUpdateManager, IDisposable
{

    #region Observable Update properties
    private readonly Dictionary<UpdateType, UpdateTypeInfo> _updateInfos;
    private readonly UpdateTypeInfo _updateInfo;
    private readonly IEnumerable<UpdateType> _trackedTypes;
    private readonly ReactiveProperty<IObservable<Update>> _tracker;
    private bool _isDisposed;
    private readonly object _lock;
    public IObservable<CallbackQuery> CallbackQuery => Selector(UpdateType.CallbackQuery, update => update.CallbackQuery);
    public IObservable<Message> ChannelPost => Selector(UpdateType.ChannelPost, update => update.ChannelPost);
    public IObservable<ChatBoostUpdated> ChatBoost => Selector(UpdateType.ChatBoost, update => update.ChatBoost);
    public IObservable<ChatJoinRequest> ChatJoinRequest => Selector(UpdateType.ChatJoinRequest, update => update.ChatJoinRequest);
    public IObservable<ChatMemberUpdated> ChatMember => Selector(UpdateType.ChatMember, update => update.ChatMember);
    public IObservable<ChosenInlineResult> ChosenInlineResult => Selector(UpdateType.ChosenInlineResult, update => update.ChosenInlineResult);
    public IObservable<Message> EditedChannelPost => Selector(UpdateType.EditedChannelPost, update => update.EditedChannelPost);
    public IObservable<Message> EditedMessage => Selector(UpdateType.EditedMessage, update => update.EditedMessage);
    public IObservable<InlineQuery> InlineQuery => Selector(UpdateType.InlineQuery, update => update.InlineQuery);
    public IObservable<Message> Message => Selector(UpdateType.Message, update => update.Message);
    public IObservable<ChatMemberUpdated> MyChatMember => Selector(UpdateType.MyChatMember, update => update.MyChatMember);
    public IObservable<Poll> Poll => Selector(UpdateType.Poll, update => update.Poll);
    public IObservable<PollAnswer> PollAnswer => Selector(UpdateType.PollAnswer, update => update.PollAnswer);
    public IObservable<PreCheckoutQuery> PreCheckoutQuery => Selector(UpdateType.PreCheckoutQuery, update => update.PreCheckoutQuery);
    public IObservable<ChatBoostRemoved> RemovedChatBoost => Selector(UpdateType.RemovedChatBoost, update => update.RemovedChatBoost);
    public IObservable<ShippingQuery> ShippingQuery => Selector(UpdateType.ShippingQuery, update => update.ShippingQuery);
    public IObservable<Update> Update => Selector(null, update => update);
    #endregion

#if NETSTANDARD2_1
  public IAsyncEnumerable<CallbackQuery> CallbackQueryEnumerable() => CallbackQuery.ToAsyncEnumerable();
  public IAsyncEnumerable<Message> ChannelPostEnumerable() => ChannelPost.ToAsyncEnumerable();
  public IAsyncEnumerable<ChatBoostUpdated> ChatBoostEnumerable() => ChatBoost.ToAsyncEnumerable();
  public IAsyncEnumerable<ChatJoinRequest> ChatJoinRequestEnumerable() => ChatJoinRequest.ToAsyncEnumerable();
  public IAsyncEnumerable<ChatMemberUpdated> ChatMemberEnumerable() => ChatMember.ToAsyncEnumerable();
  public IAsyncEnumerable<ChosenInlineResult> ChosenInlineResultEnumerable() => ChosenInlineResult.ToAsyncEnumerable();
  public IAsyncEnumerable<Message> EditedChannelPostEnumerable() => EditedChannelPost.ToAsyncEnumerable();
  public IAsyncEnumerable<Message> EditedMessageEnumerable() => EditedMessage.ToAsyncEnumerable();
  public IAsyncEnumerable<InlineQuery> InlineQueryEnumerable() => InlineQuery.ToAsyncEnumerable();
  public IAsyncEnumerable<Message> MessageEnumerable() => Message.ToAsyncEnumerable();
  public IAsyncEnumerable<ChatMemberUpdated> MyChatMemberEnumerable() => MyChatMember.ToAsyncEnumerable();
  public IAsyncEnumerable<ShippingQuery> ShippingQueryEnumerable() => ShippingQuery.ToAsyncEnumerable();
  public IAsyncEnumerable<PollAnswer> PollAnswerEnumerable() => PollAnswer.ToAsyncEnumerable();
  public IAsyncEnumerable<Poll> PollEnumerable() => Poll.ToAsyncEnumerable();
  public IAsyncEnumerable<PreCheckoutQuery> PreCheckoutQueryEnumerable() => PreCheckoutQuery.ToAsyncEnumerable();
  public IAsyncEnumerable<ChatBoostRemoved> RemovedChatBoostEnumerable() => RemovedChatBoost.ToAsyncEnumerable();
  public IAsyncEnumerable<Update> UpdateEnumerable() => Update.ToAsyncEnumerable();

#endif
    public UpdateDistributor(IObservable<Update> updateTracker)
    {
        _lock = new();
        _updateInfos = Enum.GetValues(typeof(UpdateType))
          .Cast<UpdateType>()
          .ToDictionary(x => x, _ => new UpdateTypeInfo());

        _updateInfo = new UpdateTypeInfo();

        _trackedTypes = _updateInfos.Where(x => x.Value.Listeners != 0)
           .Select(x => x.Key);

        _tracker = new ReactiveProperty<IObservable<Update>>(updateTracker);
        Set(updateTracker);
    }
    private void AddListener(UpdateType? type)
    {
        lock (_lock)
        {
            var info = GetInfo(type);
            ++info.Listeners;

            if (info.Listeners != 1)
            {
                return;
            }

            UpdateTrackerTypes();
        }
    }
    private UpdateTypeInfo GetInfo(UpdateType? type)
      => type == null ? _updateInfo : _updateInfos[(UpdateType)type];

    private void RemoveListener(UpdateType? type)
    {
        lock (_lock)
        {
            var info = GetInfo(type);
            --info.Listeners;
            if (info.Listeners != 0)
            {
                return;
            }

            UpdateTrackerTypes();
        }
    }

    private IObservable<T> Selector<T>(UpdateType? type, Func<Update, T> propertySelector)
    where T : class
    {
        return _tracker.Switch().Select(propertySelector)
          .Where(x => x != null)
          .DoOnSubscribe(() => AddListener(type))
          .Finally(() => RemoveListener(type));
    }

    public void Set(IObservable<Update> tracker)
    {
        // Configure the current tracker to listen for all types of updates
        // before switching to a new one
        (_tracker.Current as ITrackerSetup)?.Set(null);

        _tracker.OnNext(tracker);
        UpdateTrackerTypes();
    }
    private void UpdateTrackerTypes()
    {
        if (_tracker.Current is not ITrackerSetup setup)
        {
            return;
        }

        lock (_lock)
        {
            setup.Set(_updateInfo.Listeners != 0 || !_trackedTypes.Any() ?
                          null : _trackedTypes);
        }
    }

    public void Dispose() => Dispose(true);
    private void Dispose(bool explicitDisposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (explicitDisposing)
        {
            _tracker.Dispose();
        }

        _isDisposed = true;
    }

    ~UpdateDistributor() => Dispose(false);

    private sealed class UpdateTypeInfo
    {
        public int Listeners { get; set; }
    }
}
