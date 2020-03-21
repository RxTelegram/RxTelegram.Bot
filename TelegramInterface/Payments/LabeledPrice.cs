namespace TelegramInterface.Payments
{
	/// <summary>
	/// This object represents a portion of the price for goods or services.
	/// </summary>
	public class LabeledPrice
	{
		/// <summary>
		/// Portion label
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Price of the product in the smallest units of the currency (integer, not float/double).
		/// For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in
		/// <see cref="https://core.telegram.org/bots/payments/currencies.json"/> currencies.json,
		/// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
		/// </summary>
		public int Amount { get; set; }
	}
}
