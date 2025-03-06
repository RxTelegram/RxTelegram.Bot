using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Utils.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxTelegram.Bot.Api;
public class LongpollingUpdateTracker(ITelegramBot telegramBot)
  : IObservable<Update>, ITrackerSetup
{
  private readonly ITelegramBot _telegramBot = telegramBot;
  private const int NotRunning = 0;
  private const int Running = 1;
  private int _isRunning = NotRunning;
  private CancellationTokenSource _cancellationTokenSource;
  UpdateType[] _trackedUpdateTypes = [];
  readonly List<IObserver<Update>> _observers = new List<IObserver<Update>>();

  private IEnumerable<UpdateType> GetTrackingUpdateTypes()
    => _trackedUpdateTypes;
  public void Set(IEnumerable<UpdateType> types)
  {
    if (types == null && _trackedUpdateTypes == null)
      return;

    if (types == null)
    {
      _trackedUpdateTypes = null;
      _cancellationTokenSource?.Cancel();
      return;
    }

    if (_trackedUpdateTypes == null || !types.SequenceEqual(_trackedUpdateTypes))
    {
      _trackedUpdateTypes = types.ToArray();
      _cancellationTokenSource?.Cancel();
    }
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
      _cancellationTokenSource.Dispose();
      _cancellationTokenSource = null;
    }
  }

  internal async Task RunUpdate()
  {
    int? offset = null;

    while (_observers.Count != 0)
    {
      try
      {
        // if the token already canceled before the first request reset token
        if (_cancellationTokenSource.IsCancellationRequested)
          _cancellationTokenSource = new CancellationTokenSource();

        var getUpdate = new GetUpdate
        {
          Offset = offset,
          Timeout = 60,

          // if there is a null value in the list, it means that all updates are allowed
          AllowedUpdates = GetTrackingUpdateTypes() ?? null
        };
        var result = await _telegramBot.GetUpdate(getUpdate, _cancellationTokenSource.Token);
        if (!result.Any())
        {
          await Task.Delay(1000);
          continue;
        }

        offset = result.Max(x => x.UpdateId) + 1;
        NotifyObservers(result);
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
  internal void NotifyObservers(Update[] updates)
  {
    for (int uid = 0; uid != updates.Length; ++uid)
      for (int oid = 0; oid != _observers.Count; ++oid)
        _observers[oid].OnNext(updates[uid]);
  }
  internal void OnException(Exception exception)
  {
    for (int oid = 0; oid != _observers.Count; ++oid)
      _observers[oid].OnError(exception);
  }
  internal void Remove(IObserver<Update> observer)
  {
    if (!_observers.Contains(observer))
      return;

    lock (_observers)
    {
      _observers.Remove(observer);
    }

    if (!_observers.Any() && Volatile.Read(ref _isRunning) == Running)
      _cancellationTokenSource?.Cancel();
  }
  public IDisposable Subscribe(IObserver<Update> observer)
  {
    if(observer==null)
      throw new ArgumentNullException(nameof(observer));
    lock (_observers)
    {
      if (!_observers.Contains(observer))
      {
        _observers.Add(observer);
      }
    }

    if (Interlocked.Exchange(ref _isRunning, Running) == NotRunning)
    {
      Task.Run(RunUpdateSafe);
    }

    return new DisposableAction(() => Remove(observer));
  }
}