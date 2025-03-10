using System;

namespace RxTelegram.Bot.Utils.Rx;

static public class ObservableOperators
{
  static public IObservable<T> DoOnDispose<T>(this IObservable<T> source, Action onDispose)
    => new DoOnDisposeObservable<T>(source, onDispose);
  static public IObservable<T> DoOnSubscribe<T>(this IObservable<T> source, Action onSubscribe)
    => new DoOnSubscribeObservable<T>(source, onSubscribe);
  static public IObservable<KOut> Select<TIn, KOut>(this IObservable<TIn> source, Func<TIn, KOut> selector)
    => new SelectObservable<TIn, KOut>(source, selector);
  static public IObservable<T> Switch<T>(this IObservable<IObservable<T>> source)
    => new SwitchObservable<T>(source);
  static public IObservable<T> Where<T>(this IObservable<T> source, Func<T, bool> predicate)
    => new WhereObservable<T>(source, predicate);
}