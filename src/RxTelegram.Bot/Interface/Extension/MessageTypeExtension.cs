using System.Linq;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Extension;

public static class MessageTypeExtension
{
    public static MessageType GetType(this Message message)
    {
        var type = MessageType.Unknown;
        if (message.Audio != null)
        {
            type = MessageType.Audio;
        }

        if (message.Document != null)
        {
            type = MessageType.Document;
        }

        if (message.Game != null)
        {
            type = MessageType.Game;
        }

        if (message.Photo != null)
        {
            type = MessageType.Photo;
        }

        if (message.Sticker != null)
        {
            type = MessageType.Sticker;
        }

        if (message.Video != null)
        {
            type = MessageType.Video;
        }

        if (message.Voice != null)
        {
            type = MessageType.Voice;
        }

        if (message.Contact != null)
        {
            type = MessageType.Contact;
        }

        if (message.Venue != null)
        {
            type = MessageType.Venue;
        }

        if (message.Location != null)
        {
            type = MessageType.Location;
        }

        if (message.Text != null)
        {
            type = MessageType.Text;
        }

        if (message.Invoice != null)
        {
            type = MessageType.Invoice;
        }

        if (message.SuccessfulPayment != null)
        {
            type = MessageType.SuccessfulPayment;
        }

        if (message.VideoNote != null)
        {
            type = MessageType.VideoNote;
        }

        if (message.ConnectedWebsite != null)
        {
            type = MessageType.WebsiteConnected;
        }

        if (message.NewChatMembers?.Any() == true)
        {
            type = MessageType.ChatMembersAdded;
        }

        if (message.LeftChatMember != null)
        {
            type = MessageType.ChatMemberLeft;
        }

        if (message.NewChatTitle != null)
        {
            type = MessageType.ChatTitleChanged;
        }

        if (message.NewChatPhoto != null)
        {
            type = MessageType.ChatPhotoChanged;
        }

        if (message.PinnedMessage != null)
        {
            type = MessageType.MessagePinned;
        }

        if (message.DeleteChatPhoto == true)
        {
            type = MessageType.ChatPhotoDeleted;
        }

        if (message.GroupChatCreated == true)
        {
            type = MessageType.GroupCreated;
        }

        if (message.SupergroupChatCreated == true)
        {
            type = MessageType.SupergroupCreated;
        }

        if (message.ChannelChatCreated == true)
        {
            type = MessageType.ChannelCreated;
        }

        if (message.MigrateFromChatId != default)
        {
            type = MessageType.MigratedFromGroup;
        }

        if (message.MigrateToChatId != default)
        {
            type = MessageType.MigratedToSupergroup;
        }

        if (message.Poll != null)
        {
            type = MessageType.Poll;
        }

        return type;
    }
}
