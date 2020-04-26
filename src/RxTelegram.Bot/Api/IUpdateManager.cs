using System;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;
#if NETSTANDARD2_1
using System.Collections.Generic;
#endif

namespace RxTelegram.Bot.Api
{
    public interface IUpdateManager
    {
        IObservable<Update> Update { get; }

        IObservable<Message> Message { get; }

        IObservable<Message> EditedMessage { get; }

        IObservable<InlineQuery> InlineQuery { get; }

        IObservable<ChosenInlineResult> ChosenInlineResult { get; }

        IObservable<CallbackQuery> CallbackQuery { get; }

        IObservable<Message> ChannelPost { get; }

        IObservable<Message> EditedChannelPost { get; }

        IObservable<ShippingQuery> ShippingQuery { get; }

        IObservable<PreCheckoutQuery> PreCheckoutQuery { get; }

        IObservable<Poll> Poll { get; }

        IObservable<PollAnswer> PollAnswer { get; }

#if NETSTANDARD2_1
        IAsyncEnumerable<Update> UpdateEnumerable();
        IAsyncEnumerable<Message> MessageEnumerable();
        IAsyncEnumerable<Message> EditedMessageEnumerable();
        IAsyncEnumerable<InlineQuery> InlineQueryEnumerable();
        IAsyncEnumerable<ChosenInlineResult> ChosenInlineResultEnumerable();
        IAsyncEnumerable<CallbackQuery> CallbackQueryEnumerable();
        IAsyncEnumerable<Message> ChannelPostEnumerable();
        IAsyncEnumerable<Message> EditedChannelPostEnumerable();
        IAsyncEnumerable<ShippingQuery> ShippingQueryEnumerable();
        IAsyncEnumerable<PreCheckoutQuery> PreCheckoutQueryEnumerable();
        IAsyncEnumerable<Poll> PollEnumerable();
        IAsyncEnumerable<PollAnswer> PollAnswerEnumerable();
#endif
    }
}
