using System;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;

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
    }
}
