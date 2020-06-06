namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a dice with random value from 1 to 6. (Yes, we're aware of the “proper” singular of die. But it's awkward,
    /// and we decided to help it change. One dice at a time!)
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Value of the dice, 1-6 for “🎲” and “🎯” base emoji, 1-5 for “🏀” base emoji
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Emoji on which the dice throw animation is based
        /// </summary>
        public string Emoji { get; set; }
    }
}
