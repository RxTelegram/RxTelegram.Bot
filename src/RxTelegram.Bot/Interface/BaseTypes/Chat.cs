﻿using System;
using System.Threading;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Unique identifier for this chat, not exceeding 1e13 by absolute value
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Type of chat
        /// </summary>
        public ChatType Type { get; set; }

        /// <summary>
        /// Optional. Title, for channels and group chats
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Optional. Username, for private chats and channels if available
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. True if a group has 'All Members Are Admins' enabled.
        /// </summary>
        [Obsolete("Use Permissions field instead")]
        public bool AllMembersAreAdministrators { get; set; }

        /// <summary>
        /// Optional. Chat photo. Returned only in getChat.
        /// </summary>
        public ChatPhoto Photo { get; set; }

        /// <summary>
        /// Bio of the other party in a private chat. Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Optional. Description, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional. Chat invite link, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string InviteLink { get; set; }

        /// <summary>
        /// Optional. Pinned message, for supergroups. Returned only in getChat.
        /// </summary>
        public Message PinnedMessage { get; set; }

        /// <summary>
        /// Optional. Pinned message, for groups, supergroups and channels. Returned only in getChat.
        /// </summary>
        public ChatPermissions Permissions { get; set; }

        /// <summary>
        /// Optional. For supergroups, the minimum allowed delay between consecutive
        /// messages sent by each unpriviledged user. Returned only in getChat.
        /// </summary>
        public int? SlowModeDelay { get; set; }

        /// <summary>
        /// Optional. For supergroups, name of group sticker set. Returned only in getChat.
        /// </summary>
        public string StickerSetName { get; set; }

        /// <summary>
        /// Optional. True, if the bot can change the group sticker set. Returned only in getChat.
        /// </summary>
        public bool? CanSetStickerSet { get; set; }

        /// <summary>
        /// Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa;
        /// for supergroups and channel chats. This identifier may be greater than 32 bits and some programming languages
        /// may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer
        /// or double-precision float type are safe for storing this identifier.
        /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
        /// </summary>
        public long? LinkedChatId { get; set; }

        /// <summary>
        /// For supergroups, the location to which the supergroup is connected.
        /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
        /// </summary>
        public ChatLocation Location { get; set; }
    }
}
