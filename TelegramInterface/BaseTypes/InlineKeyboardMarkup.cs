namespace TelegramInterface.BaseTypes
{
	public class InlineKeyboardMarkup
	{
		/// <summary>
		/// Array of button rows, each represented by an Array of <see cref="InlineKeyboardButton"/>  objects
		/// </summary>
		public InlineKeyboardButton[][] InlineKeyboard { get; set; }
	}
}
