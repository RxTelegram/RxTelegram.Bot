﻿using System;
using System.Collections.Generic;
using System.Threading;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.Business;
using RxTelegram.Bot.Interface.Reaction;

namespace RxTelegram.Bot.Interface.BaseTypes;

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
    /// Optional. True, if the supergroup chat is a forum (has topics enabled)
    /// </summary>
    public bool? IsForum { get; set; }

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
    /// Optional. If non-empty, the list of all active chat usernames; for private chats, supergroups and channels.
    /// Returned only in <see cref="GetChat"/>.
    /// </summary>
    public List<string> ActiveUsernames { get; set; }

    /// <summary>
    /// Optional. For private chats, the date of birth of the user.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public Birthdate Birthdate { get; set; }

    /// <summary>
    /// Optional. For private chats with business accounts, the intro of the business.
    /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public BusinessIntro BusinessIntro { get; set; }

    /// <summary>
    /// Optional. For private chats with business accounts, the location of the business.
    /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public BusinessLocation BusinessLocation { get; set; }

    /// <summary>
    /// Optional. For private chats with business accounts, the opening hours of the business.
    /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public BusinessOpeningHours BusinessOpeningHours { get; set; }

    /// <summary>
    /// Optional. For private chats, the personal channel of the user.
    /// Returned only in <see cref="TelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public Chat PersonalChat { get; set; }

    /// <summary>
    /// Optional. List of available reactions allowed in the chat. If omitted, then all emoji reactions are allowed.
    /// Returned only in <see cref="GetChat"/>.
    /// </summary>
    public List<ReactionType> AvailableReactions { get; set; }

    /// <summary>
    /// Optional. Identifier of the accent color for the chat name and backgrounds of the chat photo, reply header, and link preview.
    /// See accent colors for more details. Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// Always returned in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public long? AccentColorId { get; set; }

    /// <summary>
    /// Optional. Custom emoji identifier of emoji chosen by the chat for the reply header and link preview background.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public string BackgroundCustomEmojiId { get; set; }

    /// <summary>
    /// Optional. Identifier of the accent color for the chat's profile background. See profile accent colors for more details.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public long? ProfileAccentColorId { get; set; }

    /// <summary>
    /// Optional. Custom emoji identifier of the emoji chosen by the chat for its profile background.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public string ProfileBackgroundCustomEmojiId { get; set; }

    /// <summary>
    /// Optional. Custom emoji identifier of emoji status of the other party in a private chat.
    /// Returned only in <see cref="GetChat"/>.
    /// </summary>
    public string EmojiStatusCustomEmojiId { get; set; }

    /// <summary>
    /// Optional. Expiration date of the emoji status of the other party in a private chat, if any.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public long EmojiStatusExpirationDate { get; set; }

    /// <summary>
    /// Bio of the other party in a private chat. Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public string Bio { get; set; }

    /// <summary>
    /// Optional. True, if privacy settings of the other party in the private chat allows to
    /// use tg://user?id=[user_id] links only in chats with the user. Returned only in getChat.
    /// </summary>
    public bool? HasPrivateForwards { get; set; }

    /// <summary>
    /// Optional. True, if the privacy settings of the other party restrict sending voice and
    /// video note messages in the private chat. Returned only in getChat.
    /// </summary>
    public bool? HasRestrictedVoiceAndVideoMessages { get; set; }

    /// <summary>
    /// Optional. True, if users need to join the supergroup before they can send messages.
    /// Returned only in getChat.
    /// </summary>
    public bool? JoinToSendMessages { get; set; }

    /// <summary>
    /// Optional. True, if all users directly joining the supergroup need to be approved by supergroup administrators.
    /// Returned only in getChat.
    /// </summary>
    public bool? JoinByRequest { get; set; }

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
    /// messages sent by each unprivileged user. Returned only in getChat.
    /// </summary>
    public int? SlowModeDelay { get; set; }

    /// <summary>
    /// Optional. For supergroups, the minimum number of boosts that a non-administrator user needs to add in order to ignore
    /// slow mode and chat permissions. Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public int? UnrestrictBoostCount { get; set; }

    /// <summary>
    /// Optional. The time after which all messages sent to the chat will be automatically deleted; in seconds.
    /// Returned only in getChat.
    /// </summary>
    public int? MessageAutoDeleteTime { get; set; }

    /// <summary>
    /// Optional. True, if aggressive anti-spam checks are enabled in the supergroup.
    /// The field is only available to chat administrators.
    /// Returned only in getChat.
    /// </summary>
    public bool? HasAggressiveAntiSpamEnabled { get; set; }

    /// <summary>
    /// Optional. True, if non-administrators can only get the list of bots and administrators in the chat.
    /// Returned only in getChat.
    /// </summary>
    public bool? HasHiddenMembers { get; set; }

    /// <summary>
    /// Optional. True, if messages from the chat can't be forwarded to other chats.
    /// Returned only in getChat.
    /// </summary>
    public bool? HasProtectedContent { get; set; }

    /// <summary>
    /// Optional. True, if new chat members will have access to old messages; available only to chat administrators.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public bool? HasVisibleHistory { get; set; }

    /// <summary>
    /// Optional. For supergroups, name of group sticker set. Returned only in getChat.
    /// </summary>
    public string StickerSetName { get; set; }

    /// <summary>
    /// Optional. True, if the bot can change the group sticker set.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public bool? CanSetStickerSet { get; set; }

    /// <summary>
    /// Optional. For supergroups, the name of the group's custom emoji sticker set.
    /// Custom emoji from this set can be used by all users and bots in the group.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public string CustomEmojiStickerSetName { get; set; }

    /// <summary>
    /// Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa;
    /// for supergroups and channel chats. This identifier may be greater than 32 bits and some programming languages
    /// may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer
    /// or double-precision float type are safe for storing this identifier.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public long? LinkedChatId { get; set; }

    /// <summary>
    /// For supergroups, the location to which the supergroup is connected.
    /// Returned only in <see cref="ITelegramBot.GetChat(GetChat,CancellationToken)"/>.
    /// </summary>
    public ChatLocation Location { get; set; }
}
