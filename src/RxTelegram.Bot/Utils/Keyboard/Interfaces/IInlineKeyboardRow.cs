using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils.Keyboard.Interfaces
{
    public interface IInlineKeyboardRow
    {
        public IInlineKeyboardRow AddUrl(string text, string url);

        public IInlineKeyboardRow AddLoginUrl(string text, LoginUrl loginUrl);

        public IInlineKeyboardRow AddLoginUrl(string text, string loginUrl);

        public IInlineKeyboardRow AddCallbackData(string text, string callbackData);

        public IInlineKeyboardRow AddCallbackGame(string text);

        public IInlineKeyboardRow AddSwitchInlineQuery(string text, string switchInlineQuery);

        public IInlineKeyboardRow AddSetSwitchInlineQueryCurrentChat(string text, string switchInlineQueryCurrentChat);

        public IInlineKeyboardRow AddPay(string text, bool pay);

        public IInlineKeyboardRow AddWebApp(string text, string url);

        public IInlineKeyboardBuilder EndRow();
    }
}
