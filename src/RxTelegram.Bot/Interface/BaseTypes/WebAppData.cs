namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// Contains data sent from a Web App to the bot.
    /// </summary>
    public class WebAppData
    {
        /// <summary>
        /// The data. Be aware that a bad client can send arbitrary data in this field.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Text of the web_app keyboard button, from which the Web App was opened.
        /// Be aware that a bad client can send arbitrary data in this field.
        /// </summary>
        public string ButtonText { get; set; }
    }
}
