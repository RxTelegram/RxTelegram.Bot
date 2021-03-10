namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// Represents an invite link for a chat.
    /// </summary>
    public class ChatInviteLink
    {
        /// <summary>
        /// The invite link. If the link was created by another chat administrator,
        /// then the second part of the link will be replaced with “…”.
        /// </summary>
        public string InviteLink { get; set; }

        /// <summary>
        /// Creator of the link
        /// </summary>
        public User Creator { get; set; }

        /// <summary>
        /// True, if the link is primary
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// True, if the link is revoked
        /// </summary>
        public bool IsRevoked { get; set; }

        /// <summary>
        /// Optional. Point in time (Unix timestamp) when the link will expire or has been expired
        /// </summary>
        public int ExpireDate { get; set; }

        /// <summary>
        /// Optional. Maximum number of users that can be members of the chat simultaneously after
        /// joining the chat via this invite link; 1-99999
        /// </summary>
        public int MemberLimit { get; set; }
    }
}
