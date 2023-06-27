using System;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Setup;

#if NETSTANDARD2_1
using System.Collections.Generic;
#endif

namespace RxTelegram.Bot.Api;

public interface IUpdateManager
{
    /// <summary>
    /// Updates of all Types.
    /// </summary>
    IObservable<Update> Update { get; }

    /// <summary>
    /// New incoming message of any kind — text, photo, sticker, etc.
    /// </summary>
    IObservable<Message> Message { get; }

    /// <summary>
    /// New version of a message that is known to the bot and was edited.
    /// </summary>
    IObservable<Message> EditedMessage { get; }

    /// <summary>
    /// New incoming inline query.
    /// </summary>
    IObservable<InlineQuery> InlineQuery { get; }

    /// <summary>
    /// The result of an inline query that was chosen by a user and sent to their chat partner.
    /// Please see our documentation on the feedback collecting for details on how to enable these updates for your bot.
    /// </summary>
    IObservable<ChosenInlineResult> ChosenInlineResult { get; }

    /// <summary>
    /// New incoming callback query.
    /// </summary>
    IObservable<CallbackQuery> CallbackQuery { get; }

    /// <summary>
    /// New incoming channel post of any kind — text, photo, sticker, etc.
    /// </summary>
    IObservable<Message> ChannelPost { get; }

    /// <summary>
    /// New version of a channel post that is known to the bot and was edited.
    /// </summary>
    IObservable<Message> EditedChannelPost { get; }

    /// <summary>
    /// New incoming shipping query. Only for invoices with flexible price.
    /// </summary>
    IObservable<ShippingQuery> ShippingQuery { get; }

    /// <summary>
    /// New incoming pre-checkout query. Contains full information about checkout.
    /// </summary>
    IObservable<PreCheckoutQuery> PreCheckoutQuery { get; }

    /// <summary>
    /// New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot.
    /// </summary>
    IObservable<Poll> Poll { get; }

    /// <summary>
    /// A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
    /// </summary>
    IObservable<PollAnswer> PollAnswer { get; }

#if NETSTANDARD2_1
    /// <summary>
    /// Updates of all Types.
    /// </summary>
    IAsyncEnumerable<Update> UpdateEnumerable();

    /// <summary>
    /// New incoming message of any kind — text, photo, sticker, etc.
    /// </summary>
    IAsyncEnumerable<Message> MessageEnumerable();

    /// <summary>
    /// New version of a message that is known to the bot and was edited.
    /// </summary>
    IAsyncEnumerable<Message> EditedMessageEnumerable();

    /// <summary>
    /// New incoming inline query.
    /// </summary>
    IAsyncEnumerable<InlineQuery> InlineQueryEnumerable();

    /// <summary>
    /// The result of an inline query that was chosen by a user and sent to their chat partner.
    /// Please see our documentation on the feedback collecting for details on how to enable these updates for your bot.
    /// </summary>
    IAsyncEnumerable<ChosenInlineResult> ChosenInlineResultEnumerable();

    /// <summary>
    /// New incoming callback query.
    /// </summary>
    IAsyncEnumerable<CallbackQuery> CallbackQueryEnumerable();

    /// <summary>
    /// New incoming channel post of any kind — text, photo, sticker, etc.
    /// </summary>
    IAsyncEnumerable<Message> ChannelPostEnumerable();

    /// <summary>
    /// New version of a channel post that is known to the bot and was edited.
    /// </summary>
    IAsyncEnumerable<Message> EditedChannelPostEnumerable();

    /// <summary>
    /// New incoming shipping query. Only for invoices with flexible price.
    /// </summary>
    IAsyncEnumerable<ShippingQuery> ShippingQueryEnumerable();

    /// <summary>
    /// New incoming pre-checkout query. Contains full information about checkout.
    /// </summary>
    IAsyncEnumerable<PreCheckoutQuery> PreCheckoutQueryEnumerable();

    /// <summary>
    /// New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot.
    /// </summary>
    IAsyncEnumerable<Poll> PollEnumerable();

    /// <summary>
    /// A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
    /// </summary>
    IAsyncEnumerable<PollAnswer> PollAnswerEnumerable();
#endif
}