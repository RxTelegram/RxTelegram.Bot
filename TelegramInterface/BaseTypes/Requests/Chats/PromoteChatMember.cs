namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to promote or demote a user in a supergroup or a channel. The bot must be an administrator in the chat for this to
    /// work and must have the appropriate admin rights. Pass False for all boolean parameters to demote a user. Returns True on success.
    /// </summary>
    public class PromoteChatMember
    {
        /// <summary>
        /// Required
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can change chat title, photo and other settings
        /// </summary>
        public bool CanChangeInfo { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can create channel posts, channels only
        /// </summary>
        public bool CanPostMessages { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can edit messages of other users and can pin messages, channels only
        /// </summary>
        public bool CanEditMessages { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can delete messages of other users
        /// </summary>
        public bool CanDeleteMessages { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can invite new users to the chat
        /// </summary>
        public bool CanInviteUsers { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can restrict, ban or unban chat members
        /// </summary>
        public bool CanRestrictMembers { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can pin messages, supergroups only
        /// </summary>
        public bool CanPinMessages { get; set; }

        /// <summary>
        /// Optional
        /// Pass True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that
        /// he has promoted, directly or indirectly (promoted by administrators that were appointed by him)
        /// </summary>
        public bool CanPromoteMembers { get; set; }
    }
}