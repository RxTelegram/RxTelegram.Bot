namespace TelegramInterface.BaseTypes.InputMedia
{
	public class InputMediaPhoto : BaseInputMedia
	{
		/// <summary>
		/// Type of the result, must be photo
		/// </summary>
		public override string Type { get; set; } = "photo";

		/// <summary>
		/// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Optional. Send Markdown or HTML, if you want Telegram apps to show bold,
		/// italic, fixed-width text or inline URLs in the media caption.
		/// </summary>
		public string ParseMode { get; set; }
	}
}
