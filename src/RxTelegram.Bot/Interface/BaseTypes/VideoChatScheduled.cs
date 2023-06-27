namespace RxTelegram.Bot.Interface.BaseTypes;

public class VideoChatScheduled
{
    /// <summary>
    /// Point in time (Unix timestamp) when the video chat is supposed to be started by a chat administrator
    /// </summary>
    public int StartDate { get; set; }
}
