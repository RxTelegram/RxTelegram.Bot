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
  private bool _isDisposed = false;
  private readonly object _lock;
  public IObservable<CallbackQuery> CallbackQuery => Selector(UpdateType.CallbackQuery, _update => _update.CallbackQuery);
  public IObservable<Message> ChannelPost => Selector(UpdateType.ChannelPost, _update => _update.ChannelPost);
  public IObservable<ChatBoostUpdated> ChatBoost => Selector(UpdateType.ChatBoost, _update => _update.ChatBoost);
  public IObservable<ChatJoinRequest> ChatJoinRequest => Selector(UpdateType.ChatJoinRequest, _update => _update.ChatJoinRequest);
  public IObservable<ChatMemberUpdated> ChatMember => Selector(UpdateType.ChatMember, _update => _update.ChatMember);
  public IObservable<ChosenInlineResult> ChosenInlineResult => Selector(UpdateType.ChosenInlineResult, _update => _update.ChosenInlineResult);
  public IObservable<Message> EditedChannelPost => Selector(UpdateType.EditedChannelPost, _update => _update.EditedChannelPost);
  public IObservable<Message> EditedMessage => Selector(UpdateType.EditedMessage, _update => _update.EditedMessage);
  public IObservable<InlineQuery> InlineQuery => Selector(UpdateType.InlineQuery, _update => _update.InlineQuery);
  public IObservable<Message> Message => Selector(UpdateType.Message, _update => _update.Message);
  public IObservable<ChatMemberUpdated> MyChatMember => Selector(UpdateType.MyChatMember, _update => _update.MyChatMember);
  public IObservable<Poll> Poll => Selector(UpdateType.Poll, _update => _update.Poll);
  public IObservable<PollAnswer> PollAnswer => Selector(UpdateType.PollAnswer, _update => _update.PollAnswer);
  public IObservable<PreCheckoutQuery> PreCheckoutQuery => Selector(UpdateType.PreCheckoutQuery, _update => _update.PreCheckoutQuery);
  public IObservable<ChatBoostRemoved> RemovedChatBoost => Selector(UpdateType.RemovedChatBoost, _update => _update.RemovedChatBoost);
  public IObservable<ShippingQuery> ShippingQuery => Selector(UpdateType.ShippingQuery, _update => _update.ShippingQuery);
  public IObservable<Update> Update => Selector(null, _update => _update);
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
      Console.WriteLine("Adding Listener: " + type.ToString());
      var info = GetInfo(type);
      ++info.Listeners;

      if (info.Listeners != 1) return;
      UpdateTrackerTypes();
      //info.Subscription = _tracker.Subscribe(info.Observer);
    }
  }
  private UpdateTypeInfo GetInfo(UpdateType? type)
    => type == null ? _updateInfo : _updateInfos[(UpdateType)type];

  private void RemoveListener(UpdateType? type)
  {
    lock (_lock)
    {
      Console.WriteLine("Removing Listener: " + type.ToString());
      var info = GetInfo(type);
      --info.Listeners;
      if (info.Listeners != 0) return;

      //info.Subscription.Dispose();
      //info.Subscription = null;

      UpdateTrackerTypes();
    }
  }
  public IObservable<T> Selector<T>(UpdateType? type, Func<Update, T> propertySelector)
  where T : class
  {
    return _tracker.Switch().Select(propertySelector)
      .Where(x => x != null)
      .DoOnSubscribe(() => AddListener(type))
      .DoOnDispose(() => RemoveListener(type));
  }

  public void Set(IObservable<Update> tracker)
  {
    //Setup current tracker to listen all messages before change to a new one
    var current = _tracker.Current;
    (current as ITrackerSetup)?.Set(null);
    //DisposeTrackerSubcription();
    //_tracker = tracker;
    UpdateTrackerTypes();

    _tracker.OnNext(tracker);
    //SubscribeToTracker();
  }
  // public void DisposeTrackerSubcription()
  // {
  //   _updateInfo.Subscription?.Dispose();
  //   foreach (var info in _updateInfos.Values)
  //     info.Subscription?.Dispose();
  // }
  // public void SubscribeToTracker()
  // {
  //   if (_updateInfo.Listeners != 0)
  //     _updateInfo.Subscription = _tracker.Subscribe(_updateInfo.Observer);
  //   foreach (var info in _updateInfos.Values.Where(x => x.Observer != null))
  //     info.Subscription = _tracker.Subscribe(info.Observer);
  // }
  private void UpdateTrackerTypes()
  {
    if (_tracker.Current is not ITrackerSetup setup) return;

    setup.Set(_updateInfo.Listeners != 0 || !_trackedTypes.Any() ?
      null : _trackedTypes);
  }

  public void Dispose() => Dispose(true);
  void Dispose(bool explicitDisposing)
  {
    if (_isDisposed) return;

    if (explicitDisposing)
      _tracker.Dispose();

    _isDisposed = true;
  }

  ~UpdateDistributor() => Dispose(false);

  sealed private class UpdateTypeInfo
  {
    public int Listeners { get; set; } = 0;
    // public IObserver<Update> Observer { get; set; } = null;
    // public IObservable<Update> Observable { get; set; } = null;
    // public IDisposable Subscription { get; set; } = null;
  }
}