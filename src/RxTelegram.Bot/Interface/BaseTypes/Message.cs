using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using RxTelegram.Bot.Interface.Games;
using RxTelegram.Bot.Interface.Passport;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Stickers;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a message.
/// </summary>
public class Message
{
    /// <summary>
    /// Unique message identifier
    /// </summary>
    public int MessageId { get; set; }

    /// <summary>
    /// Optional. Unique identifier of a message thread to which the message belongs; for supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Sender
    /// </summary>
    public User From { get; set; }

    /// <summary>
    /// Sender of the message, sent on behalf of a chat. The channel itself for channel messages.
    /// The supergroup itself for messages from anonymous group administrators.
    /// The linked channel for messages automatically forwarded to the discussion group
    /// </summary>
    public Chat SenderChat { get; set; }

    /// <summary>
    /// Date the message was sent
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Conversation the message belongs to
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Optional. For forwarded messages, sender of the original message
    /// </summary>
    public User ForwardFrom { get; set; }

    /// <summary>
    /// Optional. For messages forwarded from a channel, information about the original channel
    /// </summary>
    public Chat ForwardFromChat { get; set; }

    /// <summary>
    /// Optional. For forwarded channel posts, identifier of the original message in the channel
    /// </summary>
    public int? ForwardFromMessageId { get; set; }

    /// <summary>
    /// Optional. For messages forwarded from channels, signature of the post author if present
    /// </summary>
    public string ForwardSignature { get; set; }

    /// <summary>
    /// Optional. Sender's name for messages forwarded from users who disallow adding a link to their account in forwarded messages
    /// </summary>
    public string ForwardSenderName { get; set; }

    /// <summary>
    /// Optional. For forwarded messages, date the original message was sent in Unix time
    /// </summary>
    public DateTime? ForwardDate { get; set; }

    /// <summary>
    /// Optional. True, if the message is sent to a forum topic
    /// </summary>
    public bool? IsTopicMessage { get; set; }

    /// <summary>
    /// Optional. True, if the message is a channel post that was automatically forwarded to the connected discussion group
    /// </summary>
    public bool? IsAutomaticForward { get; set; }

    /// <summary>
    /// Optional. For replies, the original message. Note that the Description object in this field will
    /// not contain further reply_to_message fields even if it itself is a reply.
    /// </summary>
    public Message ReplyToMessage { get; set; }

    /// <summary>
    /// Optional. Bot through which the message was sent
    /// </summary>
    public User ViaBot { get; set; }

    /// <summary>
    /// Optional. Date the message was last edited in Unix time
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// Optional. True, if the message can't be forwarded
    /// </summary>
    public bool? HasProtectedContent { get; set; }

    /// <summary>
    /// Optional. The unique identifier of a media message group this message belongs to
    /// </summary>
    public string MediaGroupId { get; set; }

    /// <summary>
    /// Optional. Signature of the post author for messages in channels, or the custom title of an anonymous group administrator
    /// </summary>
    public string AuthorSignature { get; set; }

    /// <summary>
    /// Optional. For text messages, the actual UTF-8 text of the message
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
    /// </summary>
    public IEnumerable<MessageEntity> Entities { get; set; }

    /// <summary>
    /// Optional. For messages with a caption, special entities like usernames, URLs, bot commands, etc. that appear in the caption
    /// </summary>
    public IEnumerable<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Description is an audio file, information about the file
    /// </summary>
    public Audio Audio { get; set; }

    /// <summary>
    /// Optional. Description is a general file, information about the file
    /// </summary>
    public Document Document { get; set; }

    /// <summary>
    /// Optional. Message is an animation, information about the animation. For backward compatibility, when this
    /// field is set, the document field will also be set
    /// </summary>
    public Animation Animation { get; set; }

    /// <summary>
    /// Description is a game, information about the game.
    /// </summary>
    public Game Game { get; set; }

    /// <summary>
    /// Optional. Description is a photo, available sizes of the photo
    /// </summary>
    public IEnumerable<PhotoSize> Photo { get; set; }

    /// <summary>
    /// Optional. Description is a sticker, information about the sticker
    /// </summary>
    public Sticker Sticker { get; set; }

    /// <summary>
    /// Optional. Message is a forwarded story
    /// </summary>
    public Story Story { get; set; }

    /// <summary>
    /// Optional. Description is a video, information about the video
    /// </summary>
    public Video Video { get; set; }

    /// <summary>
    /// Description is a voice message, information about the file
    /// </summary>
    public Voice Voice { get; set; }

    /// <summary>
    /// Optional. Description is a <see cref="VideoNote"/>, information about the video message
    /// </summary>
    public VideoNote VideoNote { get; set; }

    /// <summary>
    /// Optional. Caption for the animation, audio, document, photo, video or voice
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. True, if the message media is covered by a spoiler animation
    /// </summary>
    public bool? HasMediaSpoiler { get; set; }

    /// <summary>
    /// Optional. Description is a shared contact, information about the contact
    /// </summary>
    public Contact Contact { get; set; }

    /// <summary>
    /// Optional. Description is a shared location, information about the location
    /// </summary>
    public Location Location { get; set; }

    /// <summary>
    /// Optional. Description is a venue, information about the venue
    /// </summary>
    public Venue Venue { get; set; }

    /// <summary>
    /// Optional. Message is a native poll, information about the poll
    /// </summary>
    public Poll Poll { get; set; }

    /// <summary>
    /// Optional. Message is a dice with random value from 1 to 6
    /// </summary>
    public Dice Dice { get; set; }

    /// <summary>
    /// Optional. New members that were added to the group or supergroup and information about them (the bot itself may be one of these members)
    /// </summary>
    public IEnumerable<User> NewChatMembers { get; set; }

    /// <summary>
    /// Optional. A member was removed from the group, information about them (this member may be bot itself)
    /// </summary>
    public User LeftChatMember { get; set; }

    /// <summary>
    /// Optional. A group title was changed to this value
    /// </summary>
    public string NewChatTitle { get; set; }

    /// <summary>
    /// Optional. A group photo was change to this value
    /// </summary>
    public IEnumerable<PhotoSize> NewChatPhoto { get; set; }

    /// <summary>
    /// Optional. Informs that the group photo was deleted
    /// </summary>
    public bool? DeleteChatPhoto { get; set; }

    /// <summary>
    /// Optional. Informs that the group has been created
    /// </summary>
    public bool? GroupChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: the supergroup has been created
    /// </summary>
    public bool? SupergroupChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: the channel has been created
    /// </summary>
    public bool? ChannelChatCreated { get; set; }

    /// <summary>
    /// Optional. Service message: auto-delete timer settings changed in the chat
    /// </summary>
    public MessageAutoDeleteTimerChanged MessageAutoDeleteTimerChanged { get; set; }

    /// <summary>
    /// Optional. The group has been migrated to a supergroup with the specified identifier
    /// </summary>
    public long? MigrateToChatId { get; set; }

    /// <summary>
    /// Optional. The supergroup has been migrated from a group with the specified identifier
    /// </summary>
    public long? MigrateFromChatId { get; set; }

    /// <summary>
    /// Optional. Specified message was pinned. Note that the Description object in this field
    /// will not contain further reply_to_message fields even if it is itself a reply
    /// </summary>
    public Message PinnedMessage { get; set; }

    /// <summary>
    /// Optional. Description is an invoice for a payment
    /// </summary>
    public Invoice Invoice { get; set; }

    /// <summary>
    /// Optional. Description is a service message about a successful payment
    /// </summary>
    public SuccessfulPayment SuccessfulPayment { get; set; }

    /// <summary>
    /// Optional. Service message: a user was shared with the bot
    /// </summary>
    public UserShared UserShared { get; set; }

    /// <summary>
    /// Optional. Service message: a chat was shared with the bot
    /// </summary>
    public ChatShared ChatShared { get; set; }

    /// <summary>
    /// Optional. The domain name of the website on which the user has logged in
    /// </summary>
    public string ConnectedWebsite { get; set; }

    /// <summary>
    /// Optional. Service message: the user allowed the bot added to the attachment menu to write messages
    /// </summary>
    public WriteAccessAllowed WriteAccessAllowed { get; set; }

    /// <summary>
    /// Optional. Telegram Passport data
    /// </summary>
    public PassportData PassportData { get; set; }

    /// <summary>
    /// Optional. Service message. A user in the chat triggered another user's proximity alert while sharing Live Location.
    /// </summary>
    public ProximityAlertTriggered ProximityAlertTriggered { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic created
    /// </summary>
    public ForumTopicCreated ForumTopicCreated { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic edited
    /// </summary>
    public ForumTopicEdited ForumTopicEdited { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic closed
    /// </summary>
    public ForumTopicClosed ForumTopicClosed { get; set; }

    /// <summary>
    /// Optional. Service message: forum topic reopened
    /// </summary>
    public ForumTopicReopened ForumTopicReopened { get; set; }

    /// <summary>
    /// Optional. Service message: the 'General' forum topic hidden
    /// </summary>
    public GeneralForumTopicHidden GeneralForumTopicHidden { get; set; }

    /// <summary>
    /// Optional. Service message: the 'General' forum topic unhidden
    /// </summary>
    public GeneralForumTopicUnhidden GeneralForumTopicUnhidden { get; set; }

    /// <summary>
    /// Optional. Service message: video chat scheduled
    /// </summary>
    public VideoChatScheduled VideoChatScheduled { get; set; }

    /// <summary>
    /// Optional. Service message: video chat started
    /// </summary>
    public VideoChatStarted VideoChatStarted { get; set; }

    /// <summary>
    /// Optional. Service message: video chat ended
    /// </summary>
    public VideoChatEnded VideoChatEnded { get; set; }

    /// <summary>
    /// Optional. Service message: new participants invited to a video chat
    /// </summary>
    public VideoChatParticipantsInvited VideoChatParticipantsInvited { get; set; }

    /// <summary>
    /// Optional. Service message: data sent by a Web App
    /// </summary>
    public WebAppData WebAppData { get; set; }

    /// <summary>
    /// Optional. Inline keyboard attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
