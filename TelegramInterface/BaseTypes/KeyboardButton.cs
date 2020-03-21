namespace TelegramInterface.BaseTypes
{
	public class KeyboardButton
	{
		/// <summary>
		/// Text of the button. If none of the optional fields are used, it will be sent as a message when the button is pressed
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
		/// </summary>
		public bool RequestContact { get; set; }

		/// <summary>
		/// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
		/// </summary>
		public bool RequestLocation { get; set; }

		/// <summary>
		/// Optional. If specified, the user will be asked to create a poll and send it
		/// to the bot when the button is pressed. Available in private chats only
		/// </summary>
		public KeyboardButtonPollType RequestPoll { get; set; }
	}
}
