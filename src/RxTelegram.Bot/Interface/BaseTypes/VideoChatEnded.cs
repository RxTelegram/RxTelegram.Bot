namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a service message about a video chat ended in the chat.
    /// </summary>
    public class VideoChatEnded
    {
        /// <summary>
        /// Video chat duration; in seconds
        /// </summary>
        public int Duration { get; set; }
    }
}
