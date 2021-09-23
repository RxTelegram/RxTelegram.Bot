using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils.Keyboard.Interfaces
{
    public interface IReplyKeyboardBuilder
    {
        public IReplyKeyboardRow BeginRow();

        public IEnumerable<IEnumerable<KeyboardButton>> Build();
    }
}
