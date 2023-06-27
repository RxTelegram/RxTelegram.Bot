using System.Linq;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Extension;

public static class MessageTypeExtension
{
    public static MessageType GetType(this Message message) => message switch
                                                               {
                                                                   { Audio: not null } => MessageType.Audio,
                                                                   { Document: not null } => MessageType.Document,
                                                                   { Game: not null } => MessageType.Game,
                                                                   { Photo: not null } => MessageType.Photo,
                                                                   { Sticker: not null } => MessageType.Sticker,
                                                                   { Video: not null } => MessageType.Video,
                                                                   { Voice: not null } => MessageType.Voice,
                                                                   { Contact: not null } => MessageType.Contact,
                                                                   { Venue: not null } => MessageType.Venue,
                                                                   { Location: not null } => MessageType.Location,
                                                                   { Text: not null } => MessageType.Text,
                                                                   { Invoice: not null } => MessageType.Invoice,
                                                                   { SuccessfulPayment: not null } => MessageType.SuccessfulPayment,
                                                                   { VideoNote: not null } => MessageType.VideoNote,
                                                                   { ConnectedWebsite: not null } => MessageType.WebsiteConnected,
                                                                   { NewChatMembers: not null } when message.NewChatMembers.Any() =>
                                                                       MessageType.ChatMembersAdded,
                                                                   { LeftChatMember: not null } => MessageType.ChatMemberLeft,
                                                                   { NewChatTitle: not null } => MessageType.ChatTitleChanged,
                                                                   { NewChatPhoto: not null } => MessageType.ChatPhotoChanged,
                                                                   { PinnedMessage: not null } => MessageType.MessagePinned,
                                                                   { DeleteChatPhoto: true } => MessageType.ChatPhotoDeleted,
                                                                   { GroupChatCreated: true } => MessageType.GroupCreated,
                                                                   { SupergroupChatCreated: true } => MessageType.SupergroupCreated,
                                                                   { ChannelChatCreated: true } => MessageType.ChannelCreated,
                                                                   { MigrateFromChatId: not null } when message.MigrateFromChatId != 0 =>
                                                                       MessageType.MigratedFromGroup,
                                                                   { MigrateToChatId: not null } when message.MigrateToChatId != 0 =>
                                                                       MessageType.MigratedToSupergroup,
                                                                   { Poll: not null } => MessageType.Poll,
                                                                   _ => MessageType.Unknown
                                                               };
}
