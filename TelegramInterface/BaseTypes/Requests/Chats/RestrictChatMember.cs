namespace TelegramInterface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to restrict a user in a supergroup. The bot must be an administrator in the supergroup for this to work and must
    /// have the appropriate admin rights. Pass True for all permissions to lift restrictions from a user. Returns True on success.
    /// </summary>
    public class RestrictChatMember
    {
        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// New user permissions
        /// </summary>
        public ChatPermissions Permissions { get; set; }

        /// <summary>
        /// Date when restrictions will be lifted for the user, unix time. If user is restricted for more than 366 days or less than 30
        /// seconds from the current time, they are considered to be restricted forever
        /// </summary>
        public int UntilDate { get; set; }
    }
}
