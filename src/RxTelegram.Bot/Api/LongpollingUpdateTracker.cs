using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Utils.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxTelegram.Bot.Api;
public class LongPollingUpdateTracker(ITelegramBot telegramBot)
  : IObservable<Update>, ITrackerSetup
{
    private readonly ITelegramBot _telegramBot = telegramBot;
    private const int NotRunning = 0;
    private const int Running = 1;
    private int _isRunning = NotRunning;
    private CancellationTokenSource _cancellationTokenSource;
    private UpdateType[] _trackedUpdateTypes = [];
    readonly List<IObserver<Update>> _observers = new List<IObserver<Update>>();

    public void Set(IEnumerable<UpdateType> types)
    {
        if (types == null)
        {
            if (_trackedUpdateTypes != null)
            {
                _trackedUpdateTypes = null;
                _cancellationTokenSource?.Cancel();
            }
            return;
        }

        var updateTypes = types as UpdateType[] ?? types.ToArray();
        if (_trackedUpdateTypes == null || !updateTypes.SequenceEqual(_trackedUpdateTypes))
        {
            _trackedUpdateTypes = updateTypes;
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
        catch (Exception ex)
        {
            // ignored
            ExceptionHelpers.ThrowIfFatal(ex);
        }
        finally
        {
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;

            if (!_observers.Any())
            {
                Volatile.Write(ref _isRunning, NotRunning);
            }
            else
            {
                RunUpdateTask();
            }
        }
        void RunUpdateTask() => Task.Run(RunUpdateSafe);
    }

    private int? _offset; // Offset must be preserved for all errors except TaskCanceledException.
                        // Using a local variable may cause duplicates if an exception occurs.
    internal async Task RunUpdate()
    {

        while (_observers.Count != 0)
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
                                    Offset = _offset,
                                    Timeout = 60,

                                    // if there is a null value in the list, it means that all updates are allowed
                                    AllowedUpdates = _trackedUpdateTypes
                                };

                var result = await _telegramBot.GetUpdate(getUpdate, _cancellationTokenSource.Token);
                if (!result.Any())
                {
                    await Task.Delay(1000);
                    continue;
                }

                NotifyObservers(result);

                var lastId = result.Length - 1;
                _offset = result[lastId].UpdateId + 1;
            }
            catch (TaskCanceledException)
            {
                _offset = null;
                _cancellationTokenSource = new CancellationTokenSource();
            }
            catch (Exception exception)
            {
                OnException(exception);
                throw;
            }
        }
    }
    internal void NotifyObservers(Update[] updates)
    {
        for (var uid = 0; uid != updates.Length; ++uid)
        {
            for (var oid = 0; oid != _observers.Count; ++oid)
            {
                _observers[oid].OnNext(updates[uid]);
            }
        }
    }
    internal void OnException(Exception exception)
    {
        IObserver<Update>[] current;
        lock (_observers)
        {
            current = _observers.ToArray(); // Caching current observers to prevent
                                            // notifying those who subscribed after an error occurred.
            _observers.Clear();
        }

        for (var oid = 0; oid != current.Length; ++oid)
        {
            try
            {
                current[oid].OnError(exception);
            }
            catch (Exception ex)
            {
                // Ignore exceptions from observers without an error handler,
                // as it would break the process and propagate the exception to the outer scope.
                ExceptionHelpers.ThrowIfFatal(ex);
            }
        }
    }
    internal void Remove(IObserver<Update> observer)
    {
        if (!_observers.Contains(observer))
        {
            return;
        }

        lock (_observers)
        {
            _observers.Remove(observer);
        }

        if (!_observers.Any() && Volatile.Read(ref _isRunning) == Running)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
    public IDisposable Subscribe(IObserver<Update> observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException(nameof(observer));
        }

        lock (_observers)
        {
            _observers.Add(observer);
        }

        if (Interlocked.Exchange(ref _isRunning, Running) == NotRunning)
        {
            Task.Run(RunUpdateSafe);
        }

        return new DisposableAction(() => Remove(observer));
    }
}
