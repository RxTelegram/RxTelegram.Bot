using TelegramInterface.BaseTypes.Requests;
using TelegramInterface.BaseTypes.Requests.Base.Interfaces;

namespace TelegramInterface.BaseTypes
{
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of <see cref="InlineKeyboardButton"/>  objects
        /// </summary>
        public InlineKeyboardButton[][] InlineKeyboard { get; set; }
    }
}
