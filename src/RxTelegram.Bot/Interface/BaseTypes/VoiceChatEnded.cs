namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a service message about a voice chat ended in the chat.
    /// </summary>
    public class VoiceChatEnded
    {
        /// <summary>
        /// Voice chat duration; in seconds
        /// </summary>
        public int Duration { get; set; }
    }
}
