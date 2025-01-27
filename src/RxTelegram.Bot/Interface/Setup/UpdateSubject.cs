using RxTelegram.Bot.Utils.Rx;
using System;

namespace RxTelegram.Bot.Interface.Setup;

public class UpdateSubject<T>(Func<Update, T> selector, Action onSubscribe, Action onDispose)
  : CustomSubject<Update, T>(selector, onSubscribe, onDispose)
{ }
