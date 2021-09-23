using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils.Keyboard
{
    public static class KeyboardExtensions
    {
        public static ReplyKeyboardMarkup AsReplyKeyboardMarkup(
            this IEnumerable<IEnumerable<KeyboardButton>> keyboard,
            bool? selective = null,
            bool? resizeKeyboard = null,
            string inputFieldParameter = null,
            bool? oneTimeKeyboard = null) => new()
                                             {
                                                 Keyboard = keyboard,
                                                 Selective = selective,
                                                 ResizeKeyboard = resizeKeyboard,
                                                 InputFieldPlaceholder = inputFieldParameter,
                                                 OneTimeKeyboard = oneTimeKeyboard
                                             };

        public static InlineKeyboardMarkup AsInlineKeyboardMarkup(this IEnumerable<IEnumerable<InlineKeyboardButton>> keyboard) =>
            new()
            {
                InlineKeyboard = keyboard,
            };
    }
}
