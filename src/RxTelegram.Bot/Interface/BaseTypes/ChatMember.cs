using System;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object contains information about one member of the chat.
    /// Contains all fields of the following telegram api types:
    ///     ChatMemberOwner,
    ///     ChatMemberAdministrator,
    ///     ChatMemberMember,
    ///     ChatMemberRestricted,
    ///     ChatMemberLeft,
    ///     ChatMemberBanned
    /// </summary>
    public class ChatMember
    {
        /// <summary>
        /// Information about the user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The member's status in the chat.
        /// </summary>
        public ChatMemberStatus Status { get; set; }

        /// <summary>
        /// Optional. Owner and administrators only. Custom title for this user
        /// </summary>
        public string CustomTitle { get; set; }

        /// <summary>
        /// Owner and administrators only. True, if the user's presence in the chat is hidden
        /// </summary>
        public bool? IsAnonymous { get; set; }

        /// <summary>
        /// Optional. Restricted and kicked only. Date when restrictions will be lifted for this user, UTC time
        /// </summary>
        public DateTime? UntilDate { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can access the chat event log, chat statistics,
        /// message statistics in channels, see channel members, see anonymous administrators in supergroups and ignore slow mode.
        /// Implied by any other administrator privilege
        /// </summary>
        public bool? CanManageChat { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the bot is allowed to edit administrator privileges of that user
        /// </summary>
        public bool? CanBeEdited { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can change the chat title, photo and other settings
        /// </summary>
        public bool? CanChangeInfo { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can post in the channel, channels only
        /// </summary>
        public bool? CanPostMessages { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can edit messages of other users, channels only
        /// </summary>
        public bool? CanEditMessages { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can delete messages of other users
        /// </summary>
        public bool? CanDeleteMessages { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can invite new users to the chat
        /// </summary>
        public bool? CanInviteUsers { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can restrict, ban or unban chat members
        /// </summary>
        public bool? CanRestrictMembers { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can pin messages, supergroups only
        /// </summary>
        public bool? CanPinMessages { get; set; }

        /// <summary>
        /// Optional. True, if the user is allowed to create, rename, close, and reopen forum topics; supergroups only
        /// </summary>
        public bool? CanManageTopics { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can add new administrators with a
        /// subset of his own privileges or demote administrators that he has promoted, directly or
        /// indirectly (promoted by administrators that were appointed by the user)
        /// </summary>
        public bool? CanPromoteMembers { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if the user is a member of the chat at the moment of the request
        /// </summary>
        public bool? IsMember { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if the user can send text messages, contacts, locations and venues
        /// </summary>
        public bool? CanSendMessages { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if the user can send audios, documents, photos, videos,
        /// video notes and voice notes, implies <see cref="CanSendMessages"/>
        /// </summary>
        public bool? CanSendMediaMessages { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if the user is allowed to send polls
        /// </summary>
        public bool? CanSendPolls { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if the user can send animations, games, stickers and use inline bots, implies <see cref="CanSendMediaMessages"/>
        /// </summary>
        public bool? CanSendOtherMessages { get; set; }

        /// <summary>
        /// Optional. Restricted only. True, if user may add web page previews to his messages, implies <see cref="CanSendMediaMessages"/>
        /// </summary>
        public bool? CanAddWebPagePreviews { get; set; }

        /// <summary>
        /// Optional. Administrators only. True, if the administrator can manage voice chats
        /// </summary>
        public bool? CanManageVideoChats { get; set; }
    }
}
