using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;

namespace RxTelegram.Bot.Interface.BaseTypes;

public class InlineKeyboardMarkup : IReplyMarkup
{
    /// <summary>
    /// Array of button rows, each represented by an Array of <see cref="InlineKeyboardButton"/>  objects
    /// </summary>
    public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; set; }
}