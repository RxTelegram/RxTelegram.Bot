using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils.Keyboard.Interfaces;

public interface IInlineKeyboardBuilder
{
    public IInlineKeyboardRow BeginRow();

    public IEnumerable<IEnumerable<InlineKeyboardButton>> Build();
}