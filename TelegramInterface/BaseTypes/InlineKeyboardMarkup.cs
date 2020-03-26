using System.Collections.Generic;
using TelegramInterface.BaseTypes.Requests.Base.Interfaces;

namespace TelegramInterface.BaseTypes
{
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of <see cref="InlineKeyboardButton"/>  objects
        /// </summary>
        public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; set; }
    }
}
