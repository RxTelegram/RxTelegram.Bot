using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a service message about new members invited to a video chat.
    /// </summary>
    public class VideoChatParticipantsInvited
    {
        /// <summary>
        /// Optional. New members that were invited to the video chat
        /// </summary>
        public List<User> Users { get; set; }
    }
}
