namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// Represents a join request sent to a chat.
    /// </summary>
    public class ChatJoinRequest
    {
        /// <summary>
        /// Chat to which the request was sent
        /// </summary>
        public Chat Chat { get; set; }

        /// <summary>
        /// User that sent the join request
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Date the request was sent in Unix time
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Optional. Bio of the user.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Optional. Chat invite link that was used by the user to send the join request
        /// </summary>
        public ChatInviteLink InviteLink { get; set; }
    }
}
