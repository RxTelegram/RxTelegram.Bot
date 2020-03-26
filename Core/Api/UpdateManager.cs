using System;
using Core.Reactive;
using TelegramInterface.BaseTypes;
using TelegramInterface.InlineMode;
using TelegramInterface.Payments;
using TelegramInterface.Setup;

namespace Core.Api
{
    internal class UpdateManager : IUpdateManager
    {
        private readonly Observable<Update> _update;
        private readonly Observable<Message> _message;
        private readonly Observable<Message> _editedMessage;
        private readonly Observable<InlineQuery> _inlineQuery;
        private readonly Observable<ChosenInlineResult> _chosenInlineResult;
        private readonly Observable<PollAnswer> _pollAnswer;
        private readonly Observable<Poll> _poll;
        private readonly Observable<CallbackQuery> _callbackQuery;
        private readonly Observable<Message> _channelPost;
        private readonly Observable<Message> _editedChannelPost;
        private readonly Observable<ShippingQuery> _shippingQuery;
        private readonly Observable<PreCheckoutQuery> _preCheckoutQuery;

        public IObservable<Update> Update => _update;

        public IObservable<Message> Message => _message;

        public IObservable<Message> EditedMessage => _editedMessage;

        public IObservable<InlineQuery> InlineQuery => _inlineQuery;

        public IObservable<ChosenInlineResult> ChosenInlineResult => _chosenInlineResult;

        public IObservable<CallbackQuery> CallbackQuery => _callbackQuery;

        public IObservable<Message> ChannelPost => _channelPost;

        public IObservable<Message> EditedChannelPost => _editedChannelPost;

        public IObservable<ShippingQuery> ShippingQuery => _shippingQuery;

        public IObservable<PreCheckoutQuery> PreCheckoutQuery => _preCheckoutQuery;

        public IObservable<Poll> Poll => _poll;

        public IObservable<PollAnswer> PollAnswer => _pollAnswer;

        public UpdateManager(BotInfo botInfo)
        {
            _update = new Observable<Update>();
            _editedMessage = new Observable<Message>();
            _inlineQuery = new Observable<InlineQuery>();
            _chosenInlineResult = new Observable<ChosenInlineResult>();
            _pollAnswer = new Observable<PollAnswer>();
            _poll = new Observable<Poll>();
            _callbackQuery = new Observable<CallbackQuery>();
            _channelPost = new Observable<Message>();
            _editedChannelPost = new Observable<Message>();
            _shippingQuery = new Observable<ShippingQuery>();
            _preCheckoutQuery = new Observable<PreCheckoutQuery>();
            _message = new Observable<Message>();
        }
    }
}
