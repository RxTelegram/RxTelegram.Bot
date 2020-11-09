namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// Represents a location to which a chat is connected.
    /// </summary>
    public class ChatLocation
    {
        /// <summary>
        /// The location to which the supergroup is connected. Can't be a live location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Location address; 1-64 characters, as defined by the chat owner
        /// </summary>
        public string Address { get; set; }
    }
}
