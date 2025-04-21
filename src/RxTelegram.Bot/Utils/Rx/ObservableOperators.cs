using System;

namespace RxTelegram.Bot.Utils.Rx;

public static class ObservableOperators
{
    public static IObservable<T> DoOnDispose<T>(this IObservable<T> source, Action onDispose)
      => new DoOnDisposeObservable<T>(source, onDispose);
    public static IObservable<T> DoOnSubscribe<T>(this IObservable<T> source, Action onSubscribe)
      => new DoOnSubscribeObservable<T>(source, onSubscribe);
    public static IObservable<T> Finally<T>(this IObservable<T> source, Action onTerminate)
      => new FinallyObservable<T>(source, onTerminate);
    public static IObservable<TOut> Select<TIn, TOut>(this IObservable<TIn> source, Func<TIn, TOut> selector)
      => new SelectObservable<TIn, TOut>(source, selector);
    public static IObservable<T> Switch<T>(this IObservable<IObservable<T>> source)
      => new SwitchObservable<T>(source);
    public static IObservable<T> Where<T>(this IObservable<T> source, Func<T, bool> predicate)
      => new WhereObservable<T>(source, predicate);
}
