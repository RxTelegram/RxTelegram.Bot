using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a service message about new members invited to a voice chat.
    /// </summary>
    public class VoiceChatParticipantsInvited
    {
        /// <summary>
        /// Optional. New members that were invited to the voice chat
        /// </summary>
        public List<User> Users { get; set; }
    }
}
