﻿namespace TelegramInterface.Payments
{
	/// <summary>
	/// This object represents one shipping option.
	/// <see cref="https://core.telegram.org/bots/api#shippingoption"/>
	/// </summary>
	public class ShippingOption
	{
		/// <summary>
		/// Shipping option identifier
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Option title
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// List of price portions
		/// </summary>
		public LabeledPrice[] Prices { get; set; }
	}
}
