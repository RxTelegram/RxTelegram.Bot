using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;
using System;
using System.Collections.Generic;
using System.Linq;

#if NETSTANDARD2_1

using RxTelegram.Bot.Utils;

#endif

namespace RxTelegram.Bot.Api;

public sealed class UpdateDistributor : IUpdateManager, IDisposable
{
  private IObservable<Update> _tracker;

  #region Observable Update properties
  private readonly Dictionary<UpdateType, UpdateTypeInfo> _updateInfos;
  private UpdateTypeInfo _update;
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
  public IObservable<Update> Update => (IObservable<Update>)(_update.Observer ??= new UpdateSubject<Update>(x => x,
        onSubscribe: AddGeneralListener,
        onDispose: RemoveGeneralListener));
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
    _update = new UpdateTypeInfo();
    _updateInfos = Enum.GetValues(typeof(UpdateType))
      .Cast<UpdateType>()
      .ToDictionary(x => x, _ => new UpdateTypeInfo());
    Set(updateTracker);
  }

  private void AddGeneralListener()
  {
    ++_update.Listeners;

    (_tracker as ITrackerSetup)?.Set(null);

    _update.Subscription ??= _tracker.Subscribe(_update.Observer);
  }
  private void AddListener(UpdateType type)
  {
    var updateType = _updateInfos[type];
    ++updateType.Listeners;

    UpdateTrackerTypes();

    updateType.Subscription ??= _tracker.Subscribe(updateType.Observer);
  }
  private void RemoveGeneralListener()
  {
    --_update.Listeners;
    _update.Subscription?.Dispose();
    _update.Subscription = null;

    UpdateTrackerTypes();
  }
  private void RemoveListener(UpdateType type)
  {
    var updateType = _updateInfos[type];
    --updateType.Listeners;
    _update.Subscription?.Dispose();
    _update.Subscription = null;

    UpdateTrackerTypes();
  }
  public IObservable<T> Selector<T>(UpdateType updateType, Func<Update, T> propertySelector)
  where T: class
  {
    var info = _updateInfos[updateType];
    if (info.Observer != null)
      return (IObservable<T>)info.Observer;

    var subject = new UpdateSubject<T>(propertySelector,
         onSubscribe: () => AddListener(updateType),
         onDispose: () => RemoveListener(updateType));
    info.Observer = subject;
    info.Subscription = _tracker.Subscribe(info.Observer);
    return subject;
  }
  public void Set(IObservable<Update> tracker)
  {
    //Setup current tracker to listen all messages before change to a new one
    (_tracker as ITrackerSetup)?.Set(null);
    DisposeTrackerSubcription();
    _tracker = tracker;
    UpdateTrackerTypes();
    SubscribeToTracker();
  }
  public void DisposeTrackerSubcription()
  {
    _update.Subscription?.Dispose();
    foreach (var info in _updateInfos.Values)
      info.Subscription?.Dispose();
  }
  public void SubscribeToTracker()
  {
    if(_update.Observer!=null)
    _update.Subscription = _tracker.Subscribe(_update.Observer);
    foreach (var info in _updateInfos.Values.Where(x=>x.Observer!=null))
      info.Subscription = _tracker.Subscribe(info.Observer);
  }
  private void UpdateTrackerTypes()
  {
    if (_tracker is not ITrackerSetup) return;

    IEnumerable<UpdateType> types = null;
    if (_update.Listeners == 0)
    {
      types = _updateInfos.Where(x => x.Value.Listeners != 0).Select(x => x.Key);
      if (!types.Any())
        types = null;
    }
      (_tracker as ITrackerSetup).Set(types);
  }

  public void Dispose() => DisposeTrackerSubcription();

  sealed private class UpdateTypeInfo
  {
    public int Listeners { get; set; } = 0;
    public IObserver<Update> Observer { get; set; } = null;
    public IDisposable Subscription { get; set; } = null;
  }
}