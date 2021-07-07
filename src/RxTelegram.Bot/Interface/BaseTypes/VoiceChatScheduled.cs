namespace RxTelegram.Bot.Interface.BaseTypes
{
    public class VoiceChatScheduled
    {
        /// <summary>
        /// Point in time (Unix timestamp) when the voice chat is supposed to be started by a chat administrator
        /// </summary>
        public int StartDate { get; set; }
    }
}
