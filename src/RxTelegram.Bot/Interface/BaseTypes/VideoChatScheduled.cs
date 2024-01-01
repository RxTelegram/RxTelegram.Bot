using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a service message about a video chat scheduled in the chat.
/// </summary>
public class VideoChatScheduled
{
    /// <summary>
    /// Point in time (Unix timestamp) when the video chat is supposed to be started by a chat administrator
    /// </summary>
    public DateTime StartDate { get; set; }
}
