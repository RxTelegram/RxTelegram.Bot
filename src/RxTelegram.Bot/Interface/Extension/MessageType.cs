namespace RxTelegram.Bot.Interface.Extension;

public enum MessageType
{
    Unknown = 0,
    Audio = 1,
    Document = 2,
    Game = 3,
    Photo = 4,
    Sticker = 5,
    Video = 6,
    Voice = 7,
    Contact = 8,
    Venue = 9,
    Location = 10,
    Text = 11,
    Invoice = 12,
    SuccessfulPayment = 13,
    VideoNote = 14,
    WebsiteConnected = 15,
    ChatMembersAdded = 16,
    ChatMemberLeft = 17,
    Poll = 18,
    MigratedToSupergroup = 19,
    MigratedFromGroup = 20,
    ChannelCreated = 21,
    SupergroupCreated = 22,
    GroupCreated = 23,
    ChatPhotoDeleted = 24,
    MessagePinned = 25,
    ChatPhotoChanged = 26,
    ChatTitleChanged = 27
}