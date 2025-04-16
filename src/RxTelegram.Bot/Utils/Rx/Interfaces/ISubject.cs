using System;

namespace RxTelegram.Bot.Utils.Rx.Interfaces;

public interface ISubject<in Tin, out Tout> : IObserver<Tin>, IObservable<Tout> { }
public interface ISubject<T> : ISubject<T, T> { }