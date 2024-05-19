using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Bot;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Callbacks;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Forum;
using RxTelegram.Bot.Interface.BaseTypes.Requests.GeneralForum;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Users;
using RxTelegram.Bot.Interface.Business;
using RxTelegram.Bot.Interface.Business.Requests;
using RxTelegram.Bot.Interface.Games;
using RxTelegram.Bot.Interface.Games.Requests;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Passport.Requests;
using RxTelegram.Bot.Interface.Payments.Requests;
using RxTelegram.Bot.Interface.Reaction.Requests;
using RxTelegram.Bot.Interface.Setup;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Requests;
using File = RxTelegram.Bot.Interface.BaseTypes.File;

namespace RxTelegram.Bot;

public interface ITelegramBot
{
    IUpdateManager Updates { get; }

    /// <summary>
    ///     Use this method to get basic info about a file and prepare it for downloading.
    ///     For the moment, bots can download files of up to 20MB in size.
    ///     The file can then be downloaded via the link https://api.telegram.org/file/bot{token}/{file_path}, where {file_path} is taken from the
    ///     response.
    ///     It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling getFile
    ///     again.
    /// </summary>
    /// <param name="fileId">FileId of the File.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, a File object is returned.</returns>
    Task<File> GetFile(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Provides a stream for a file to download it.
    /// </summary>
    /// <param name="filePath">Identifier for the file.</param>
    /// <returns>A stream for the given file.</returns>
    Task<Stream> DownloadFileStream(string filePath);

    /// <summary>
    ///     Provides a file in string representation.
    /// </summary>
    /// <param name="filePath">Identifier for the file.</param>
    /// <returns>String representation of the given file.</returns>
    Task<string> DownloadFileString(string filePath);

    /// <summary>
    ///     Provides a file as a byte array.
    /// </summary>
    /// <param name="filePath">Identifier for the file.</param>
    /// <returns>A byte array of the given file.</returns>
    Task<byte[]> DownloadFileByteArray(string filePath);

    /// <summary>
    ///     A simple method for testing your bot's auth token.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns basic information about the bot in form of a <see cref="User" /> object.</returns>
    Task<User> GetMe(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send text messages.
    /// </summary>
    /// <param name="sendMessage">Details for the message you want to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendMessage(SendMessage sendMessage, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to forward messages of any kind.
    /// </summary>
    /// <param name="forwardMessage">Details for the message that should be forwarded to a different Chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> ForwardMessage(ForwardMessage forwardMessage, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send photos
    /// </summary>
    /// <param name="sendPhoto">Details for the photo to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendPhoto(SendPhoto sendPhoto, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send audio files, if you want Telegram clients to display them in the music player.
    ///     Your audio must be in the .MP3 or .M4A format. Bots can currently send audio files of up to 50 MB in size,
    ///     this limit may be changed in the future.
    ///     For sending voice messages, use the sendVoice method instead.
    /// </summary>
    /// <param name="sendAudio">Details for the audio to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendAudio(SendAudio sendAudio, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send general files. Bots can currently send files of any type of up to 50 MB in size,
    ///     this limit may be changed in the future.
    /// </summary>
    /// <param name="sendDocument">Details for the document/file to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendDocument(SendDocument sendDocument, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document).
    ///     Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    /// <param name="sendVideo">Details for the video to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendVideo(SendVideo sendVideo, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound).
    ///     Bots can currently send animation files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    /// <param name="sendAnimation">Details for the animation to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendAnimation(SendAnimation sendAnimation, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message.
    ///     For this to work, your audio must be in an .OGG file encoded with OPUS (other formats may be sent as Audio or Document).
    ///     Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    /// <param name="sendVoice">Details for the voice message to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendVoice(SendVoice sendVoice, CancellationToken cancellationToken = default);

    /// <summary>
    ///     As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long. Use this method to send video messages.
    /// </summary>
    /// <param name="sendVideoNote">Details for the video note to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendVideoNote(SendVideoNote sendVideoNote, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send a group of photos or videos as an album.
    /// </summary>
    /// <param name="sendMediaGroup">Details for the media group to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message[]> SendMediaGroup(SendMediaGroup sendMediaGroup, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send point on the map.
    /// </summary>
    /// <param name="sendLocation">Details for the location to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendLocation(SendLocation sendLocation, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to create a new sticker set owned by a user. The bot will be able to edit the sticker set thus created.
    ///     You must use exactly one of the fields png_sticker or tgs_sticker.
    /// </summary>
    /// <param name="createNewStickerSet">Details for the sticker set to create.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns true on success, otherwise false.</returns>
    Task<bool> CreateNewStickerSet(CreateNewStickerSet createNewStickerSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to edit live location messages.
    ///     A location can be edited until its live_period expires or editing is explicitly disabled by a call to StopMessageLiveLocation>.
    /// </summary>
    /// <param name="editMessageLiveLocation">Details for the live location to edit.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if the edited message was sent by the bot, the edited <see cref="Message" /> is returned, otherwise True is returned.</returns>
    Task<Message> EditMessageLiveLocation(EditMessageLiveLocation editMessageLiveLocation, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get up to date information about the chat (current name of the user for one-on-one conversations,
    ///     current username of a user, group or channel, etc.)
    /// </summary>
    /// <param name="getChat">ChatId for the request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns a <see cref="Chat" /> object on success.</returns>
    Task<Chat> GetChat(GetChat getChat, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get information about a member of a chat.
    /// </summary>
    /// <param name="getChatMember">UserId of the chat member.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns a <see cref="ChatMember" /> object on success.</returns>
    Task<ChatMember> GetChatMember(GetChatMember getChatMember, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get a sticker set.
    /// </summary>
    /// <param name="getStickerSet">Name of the sticker set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, a <see cref="StickerSet" /> object is returned.</returns>
    Task<StickerSet> GetStickerSet(GetStickerSet getStickerSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get a list of profile pictures for a user.
    /// </summary>
    /// <param name="getUserProfilePhotos">Filter for the requested username.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns a <see cref="UserProfilePhotos" /> object.</returns>
    Task<UserProfilePhotos> GetUserProfilePhotos(GetUserProfilePhotos getUserProfilePhotos, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get a list of administrators in a chat.
    /// </summary>
    /// <param name="getChatAdministrators">ChatId for the request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>
    ///     On success, returns an Array of <see cref="ChatMember" /> objects that contains information about all chat administrators except other
    ///     bots.
    ///     If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
    /// </returns>
    Task<IEnumerable<ChatMember>> GetChatAdministrators(
        GetChatAdministrators getChatAdministrators,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get the number of members in a chat.
    /// </summary>
    /// <param name="getChatMemberCount">ChatId for the request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns Int on success.</returns>
    Task<int> GetChatMemberCount(GetChatMemberCount getChatMemberCount, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to kick a user from a group, a supergroup or a channel. In the case of supergroups and channels, the user will
    ///     not be able to return to the group on their own using invite links, etc., unless unbanned first. The bot must be an
    ///     administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="banChatMember">UserId for the user to kick.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> BanChatMember(BanChatMember banChatMember, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to delete a message, including service messages, with the following limitations:
    ///     - A message can only be deleted if it was sent less than 48 hours ago.
    ///     - A dice message in a private chat can only be deleted if it was sent more than 24 hours ago.
    ///     - Bots can delete outgoing messages in private chats, groups, and supergroups.
    ///     - Bots can delete incoming messages in private chats.
    ///     - Bots granted can_post_messages permissions can delete outgoing messages in channels.
    ///     - If the bot is an administrator of a group, it can delete any message there.
    ///     - If the bot has can_delete_messages permission in a supergroup or a channel, it can delete any message there.
    /// </summary>
    /// <param name="deleteMessage">Identifier of the message to delete.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteMessage(DeleteMessage deleteMessage, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to delete a chat photo. Photos can't be changed for private chats.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="deleteChatPhoto">ChatId for the request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteChatPhoto(DeleteChatPhoto deleteChatPhoto, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method for your bot to leave a group, supergroup or channel.
    /// </summary>
    /// <param name="leaveChat">ChatId for the request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> LeaveChat(LeaveChat leaveChat, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to add a new sticker to a set created by the bot.
    /// The format of the added sticker must match the format of the other stickers in the set.
    /// Emoji sticker sets can have up to 200 stickers.
    /// Animated and video sticker sets can have up to 50 stickers.
    /// Static sticker sets can have up to 120 stickers.
    /// </summary>
    /// <param name="addStickerToSet">Details for adding stickers to a set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> AddStickerToSet(AddStickerToSet addStickerToSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to delete a sticker from a set created by the bot.
    /// </summary>
    /// <param name="deleteStickerFromSet">Identifier of the sticker set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteStickerFromSet(DeleteStickerFromSet deleteStickerFromSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to pin a message in a group, a supergroup, or a channel.
    ///     The bot must be an administrator in the chat for this to work and must have the 'can_pin_messages' admin right in the supergroup
    ///     or 'can_edit_messages' admin right in the channel.
    /// </summary>
    /// <param name="pinChatMessage">Identifier of the message that should be pinned.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> PinChatMessage(PinChatMessage pinChatMessage, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to unpin a message in a group, a supergroup, or a channel.The bot must be an administrator in the chat for this
    ///     to work and must have the 'can_pin_messages' admin right in the supergroup or 'can_edit_messages' admin right in the channel.
    /// </summary>
    /// <param name="unpinChatMessage">ChatId of the chat whose message should be unpinned.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnpinChatMessage(UnpinChatMessage unpinChatMessage, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to change the description of a group, a supergroup or a channel.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="setChatDescription">Details for the Chat whose description should be edited.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatDescription(SetChatDescription setChatDescription, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set default chat permissions for all members.
    ///     The bot must be an administrator in the group or a supergroup for this to work and must have the can_restrict_members admin rights.
    /// </summary>
    /// <param name="setChatPermissions">Permissions that should be set for the given chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatPermissions(SetChatPermissions setChatPermissions, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to change the title of a chat. Titles can't be changed for private chats.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="setChatTitle">Title that should be set for the given chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatTitle(SetChatTitle setChatTitle, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set a new group sticker set for a supergroup.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    ///     Use the field CanSetStickerSet optionally returned in getChat requests to check if the bot can use this method.
    /// </summary>
    /// <param name="setChatStickerSet">Sticker set that should be set for the given chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<bool> SetChatStickerSet(SetChatStickerSet setChatStickerSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to delete a group sticker set from a supergroup.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    ///     Use the field CanSetStickerSet optionally returned in getChat requests to check if the bot can use this method.
    /// </summary>
    /// <param name="deleteChatStickerSet">Deletes the sticker set from a chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteChatStickerSet(DeleteChatStickerSet deleteChatStickerSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set the thumbnail of a sticker set. Animated thumbnails can be set for animated sticker sets only.
    /// </summary>
    /// <param name="setStickerSetThumbnail">Sets the thumbnail picture for the sticker set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerSetThumbnail(SetStickerSetThumbnail setStickerSetThumbnail, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send static .WEBP or animated .TGS stickers.
    /// </summary>
    /// <param name="sendSticker">Details for the sticker to send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent Message is returned.</returns>
    Task<Message> SendSticker(SendSticker sendSticker, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set a new profile photo for the chat. Photos can't be changed for private chats.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="setChatPhoto">Sets the photo for a given chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatPhoto(SetChatPhoto setChatPhoto, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to generate a new invite link for a chat; any previously generated link is revoked.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <remarks>
    ///     Note: Each administrator in a chat generates their own invite links. Bots can't use invite links generated by other administrators.
    ///     If you want your bot to work with invite links, it will need to generate its own link using exportChatInviteLink —
    ///     after this the link will become available to the bot via the getChat method.
    ///     If your bot needs to generate a new invite link replacing its previous one, use exportChatInviteLink again.
    /// </remarks>
    /// <param name="exportChatInviteLink">ChatId for the request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the new invite link on success.</returns>
    Task<string> ExportChatInviteLink(ExportChatInviteLink exportChatInviteLink, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to promote or demote a user in a supergroup or a channel.
    ///     The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    ///     Pass False for all boolean parameters to demote a user
    /// </summary>
    /// <param name="promoteChatMember">Permissions that should be granted to a chat member.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> PromoteChatMember(PromoteChatMember promoteChatMember, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to restrict a user in a supergroup.
    ///     The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights.
    ///     Pass True for all permissions to lift restrictions from a user.
    /// </summary>
    /// <param name="restrictChatMember">Permissions that should be restricted form a chat member.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> RestrictChatMember(RestrictChatMember restrictChatMember, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send phone contacts.
    /// </summary>
    /// <param name="sendContact">Details for the contact that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendContact(SendContact sendContact, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to upload a .PNG file with a sticker for later use in createNewStickerSet and addStickerToSet methods (can be used
    ///     multiple times).
    /// </summary>
    /// <param name="uploadStickerFile">Stickerfile that should be uploaded.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the uploaded <see cref="File" /> on success.</returns>
    Task<File> UploadStickerFile(UploadStickerFile uploadStickerFile, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to edit text and game messages.
    /// </summary>
    /// <param name="editMessageText">Details for the message that should be edited.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
    Task<Message> EditMessageText(EditMessageText editMessageText, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to move a sticker in a set created by the bot to a specific position.
    /// </summary>
    /// <param name="setStickerPositionInSet">Details for the sticker that should be repositioned in the sticker set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerPositionInSet(SetStickerPositionInSet setStickerPositionInSet, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method when you need to tell the user that something is happening on the bot's side.
    ///     The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
    /// </summary>
    /// <param name="sendChatAction">Action that should be send to a chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SendChatAction(SendChatAction sendChatAction, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send a native poll.
    /// </summary>
    /// <param name="sendPoll">Details for the poll that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent Message is returned.</returns>
    Task<bool> SendPoll(SendPoll sendPoll, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to stop a poll which was sent by the bot.
    /// </summary>
    /// <param name="stopPoll">MessageId of the poll that should be stoped</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the stopped Poll with the final results is returned.</returns>
    Task<Poll> StopPoll(StopPoll stopPoll, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
    /// </summary>
    /// <param name="setChatAdministratorCustomTitle">Details for the custom title.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatAdministratorCustomTitle(
        SetChatAdministratorCustomTitle setChatAdministratorCustomTitle,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to unban a previously kicked user in a supergroup or channel.
    ///     The user will not return to the group or channel automatically, but will be able to join via link, etc.
    ///     The bot must be an administrator for this to work.
    /// </summary>
    /// <param name="unbanChatMember">UserId of the chat member that should be unbanned.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnbanChatMember(UnbanChatMember unbanChatMember, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send a game.
    /// </summary>
    /// <param name="sendGame">Details for the game that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendGame(SendGame sendGame, CancellationToken cancellationToken = default);

    Task<bool> SetGameScoreInlineMessage(SetGameScore setGameScore, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set the score of the specified user in a game.
    /// </summary>
    /// <param name="setGameScore">Details for the game score that should be set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>
    ///     On success, if the message was sent by the bot, returns the edited Message, otherwise returns True.
    ///     Returns an error, if the new score is not greater than the user's current score in the chat and force is False.
    /// </returns>
    Task<Message> SetGameScore(SetGameScore setGameScore, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get data for high score tables.
    /// </summary>
    /// <param name="getGameHighScores">Details for the game highscore Request.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>
    ///     Will return the score of the specified user and several of their neighbors in a game.
    ///     On success, returns an Array of GameHighScore objects.
    /// </returns>
    Task<IEnumerable<GameHighScore>> GetGameHighScores(GetGameHighScores getGameHighScores, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to stop updating a live location message before live_period expires.
    /// </summary>
    /// <param name="stopMessageLiveLocation">MessageId of the liveLocation that should be stopped.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if the message was sent by the bot, the sent Message is returned, otherwise True is returned.</returns>
    Task<Message> StopMessageLiveLocation(StopMessageLiveLocation stopMessageLiveLocation, CancellationToken cancellationToken = default);

    Task<bool> StopMessageLiveLocationInlineMessage(
        StopMessageLiveLocation stopMessageLiveLocation,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send answers to callback queries sent from inline keyboards.
    ///     The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
    /// </summary>
    /// <param name="answerCallbackQuery">Answer details for the callback query.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, True is returned.</returns>
    Task<bool> AnswerCallbackQuery(AnswerCallbackQuery answerCallbackQuery, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send answers to an inline query. No more than 50 results per query are allowed.
    /// </summary>
    /// <param name="answerInlineQuery">Answer details for the inline query.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, True is returned.</returns>
    Task<bool> AnswerInlineQuery(AnswerInlineQuery answerInlineQuery, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to set the result of an interaction with a Web App and send a corresponding message
    ///     on behalf of the user to the chat from which the query originated.
    /// </summary>
    /// <param name="answerWebAppQuery">Answer details for web app query.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, a SentWebAppMessage object is returned.</returns>
    Task<SentWebAppMessage> AnswerWebAppQuery(AnswerWebAppQuery answerWebAppQuery, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get the current list of the bot's commands.
    /// </summary>
    /// <param name="getMyCommands">Bot scope and language definition</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns Array of <see cref="BotCommand" /> on success.</returns>
    Task<IEnumerable<BotCommand>> GetMyCommands(GetMyCommands getMyCommands, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to change the list of the bot's commands. At most 100 commands can be specified.
    /// </summary>
    /// <param name="setMyCommands">Bot commands that should be set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetMyCommands(SetMyCommands setMyCommands, CancellationToken cancellationToken = default);

    Task<bool> DeleteMyCommands(DeleteMyCommands deleteMyCommands, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send information about a venue.
    /// </summary>
    /// <param name="sendVenue">Details of the Venue that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent <see cref="Message" /> is returned.</returns>
    Task<Message> SendVenue(SendVenue sendVenue, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to edit captions of messages.
    /// </summary>
    /// <param name="editMessageCaption">Details for the message caption that should be edited.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
    Task<Message> EditMessageCaption(EditMessageCaption editMessageCaption, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to edit only the reply markup of messages.
    /// </summary>
    /// <param name="editMessageReplyMarkup">New reply markup for the message.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
    Task<Message> EditMessageReplyMarkup(EditMessageReplyMarkup editMessageReplyMarkup, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send invoices.
    /// </summary>
    /// <param name="sendInvoice">Details for the invoice that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent Message is returned.</returns>
    Task<Message> SendInvoice(SendInvoice sendInvoice, CancellationToken cancellationToken = default);

    /// <summary>
    ///     If you sent an invoice requesting a shipping address and the parameter is_flexible was specified,
    ///     the Bot API will send an Update with a shipping_query field to the bot. Use this method to reply to shipping queries.
    /// </summary>
    /// <param name="answerShippingQuery">Details for answering a shipping query.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, True is returned.</returns>
    Task<bool> AnswerShippingQuery(AnswerShippingQuery answerShippingQuery, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Once the user has confirmed their payment and shipping details, the Bot API sends the final confirmation in the form of an
    ///     Update with the field pre_checkout_query. Use this method to respond to such pre-checkout queries.
    /// </summary>
    /// <remarks>Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.</remarks>
    /// <param name="answerPreCheckoutQuery">Answer for the preCheckoutQuery</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, True is returned.</returns>
    Task<bool> AnswerPreCheckoutQuery(AnswerPreCheckoutQuery answerPreCheckoutQuery, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Informs a user that some of the Telegram Passport elements they provided contains errors.
    ///     The user will not be able to re-submit their Passport to you until the errors are fixed
    ///     (the contents of the field for which you returned the error must change).
    /// </summary>
    /// <remarks>
    ///     Use this if the data submitted by the user doesn't satisfy the standards your service requires for any reason.
    ///     For example, if a birthday date seems invalid, a submitted document is blurry, a scan shows evidence of tampering, etc.
    ///     Supply some details in the error message to make sure the user knows how to correct the issues.
    /// </remarks>
    /// <param name="setPassportDataErrors">Error that should be set on the passport data.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetPassportDataErrors(SetPassportDataErrors setPassportDataErrors, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to edit animation, audio, document, photo, or video messages.
    ///     If a message is a part of a message album, then it can be edited only to a photo or a video.
    ///     Otherwise, message type can be changed arbitrarily. When inline message is edited, new file can't be uploaded.
    ///     Use previously uploaded file via its file_id or specify a URL.
    /// </summary>
    /// <param name="editMessageMedia">Details for the changes of the message media.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, if the edited message was sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
    Task<bool> EditMessageMedia(EditMessageMedia editMessageMedia, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to send an animated emoji that will display a random value.
    /// </summary>
    /// <param name="sendDice">Details for the dice that should be send.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, the sent Message is returned.</returns>
    Task<Message> SendDice(SendDice sendDice, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to receive incoming updates using long polling. An Array of Update objects is returned.
    /// </summary>
    /// <remarks>
    ///     1. This method will not work if an outgoing webhook is set up.
    ///     2. In order to avoid getting duplicate updates, recalculate offset after each server response.
    /// </remarks>
    /// <param name="update">Filter for the requested updates.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>A list of all Updates belonging to your bot.</returns>
    Task<Update[]> GetUpdate(GetUpdate update, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to specify a url and receive incoming updates via an outgoing webhook.
    ///     Whenever there is an update for the bot, we will send an HTTPS POST request to the specified url, containing a JSON-serialized
    ///     Update. In case of an unsuccessful request, we will give up after a reasonable amount of attempts. Returns True on success.
    ///     If you'd like to make sure that the Webhook request comes from Telegram, we recommend using a secret path in the URL,
    ///     e.g. https://www.example.com/{token}. Since nobody else knows your bot's token, you can be pretty sure it's us.
    /// </summary>
    /// <param name="setWebhook">Details for the webhook to set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>True if the webhook could be set successfully, otherwise false.</returns>
    Task<bool> SetWebhook(SetWebhook setWebhook, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to remove webhook integration if you decide to switch back to getUpdates. Returns True on success.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>True if the webhook could be deleted successfully, otherwise false.</returns>
    Task<bool> DeleteWebhook(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Use this method to get current webhook status. If the bot is using getUpdates, will return an object with the url field empty.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>On success, returns a WebhookInfo object.</returns>
    Task<WebhookInfo> GetWebhookInfo(CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to log out from the cloud Bot API server before launching the bot locally.
    /// You must log out the bot before running it locally, otherwise there is no guarantee that the bot will receive updates.
    /// After a successful call, you can immediately log in on a local server, but will not be able to log in back to the cloud
    /// Bot API server for 10 minutes.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success</returns>
    Task<bool> LogOut(CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to close the bot instance before moving it from one local server to another. You need to delete the webhook
    /// before calling this method to ensure that the bot isn't launched again after server restart.
    /// The method will return error 429 in the first 10 minutes after the bot is launched.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> Close(CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to clear the list of pinned messages in a chat. If the chat is not a private chat, the bot must be an
    /// administrator in the chat for this to work and must have the 'can_pin_messages' admin right in a supergroup or
    /// 'can_edit_messages' admin right in a channel.
    /// </summary>
    /// <param name="unpinAllChatMessages">Details for the messages to unpin</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnpinAllChatMessages(UnpinAllChatMessages unpinAllChatMessages, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to copy messages of any kind.
    /// The method is analogous to the method forwardMessages, but the copied message doesn't have a link to the original message.
    /// </summary>
    /// <param name="copyMessage">Details for the message to copy</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the <see cref="MessageIdObject"/> of the sent message on success.</returns>
    Task<MessageIdObject> CopyMessage(CopyMessage copyMessage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to create an additional invite link for a chat.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// The link can be revoked using the method revokeChatInviteLink.
    /// </summary>
    /// <param name="createChatInviteLink">Details for the chat invite link to create.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the new invite link as <see cref="ChatInviteLink"/>.</returns>
    Task<ChatInviteLink> CreateChatInviteLink(CreateChatInviteLink createChatInviteLink, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to edit a non-primary invite link created by the bot.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="editChatInviteLink">Details for the chat invite link to edit.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the edited invite link as a <see cref="ChatInviteLink"/>  object.</returns>
    Task<ChatInviteLink> EditChatInviteLink(EditChatInviteLink editChatInviteLink, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to revoke an invite link created by the bot.
    /// If the primary link is revoked, a new link is automatically generated.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// </summary>
    /// <param name="revokeChatInviteLink">Details for the invite link to revoke.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the revoked invite link as <see cref="ChatInviteLink"/>  object.</returns>
    Task<ChatInviteLink> RevokeChatInviteLink(RevokeChatInviteLink revokeChatInviteLink, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to approve a chat join request.
    /// The bot must be an administrator in the chat for this to work and must have the can_invite_users administrator right.
    /// </summary>
    /// <param name="approveChatJoinRequest">Join request to approve</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> ApproveChatJoinRequest(ApproveChatJoinRequest approveChatJoinRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to decline a chat join request.
    /// The bot must be an administrator in the chat for this to work and must have the can_invite_users administrator right.
    /// </summary>
    /// <param name="declineChatJoinRequest">Join request to decline</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeclineChatJoinRequest(DeclineChatJoinRequest declineChatJoinRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to ban a channel chat in a supergroup or a channel.
    /// Until the chat is unbanned, the owner of the banned chat won't be able to send messages on behalf of any of their channels.
    /// The bot must be an administrator in the supergroup or channel for this to work and must have the appropriate administrator rights.
    /// </summary>
    /// <param name="banChatSenderChat">Sender to ban</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> BanChatSenderChat(BanChatSenderChat banChatSenderChat, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to ban a channel chat in a supergroup or a channel.
    /// Until the chat is unbanned, the owner of the banned chat won't be able to send messages on behalf of any of their channels.
    /// The bot must be an administrator in the supergroup or channel for this to work and must have the appropriate administrator rights.
    /// </summary>
    /// <param name="unbanChatSenderChat">Sender to ban</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnbanChatSenderChat(UnbanChatSenderChat unbanChatSenderChat, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the bot's menu button in a private chat, or the default menu button.
    /// </summary>
    /// <param name="setChatMenuButton">Definition for chat menu button.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetChatMenuButton(SetChatMenuButton setChatMenuButton, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the current value of the bot's menu button in a private chat, or the default menu button.
    /// </summary>
    /// <param name="getChatMenuButton">Chat id for the chat.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns MenuButton on success.</returns>
    Task<MenuButton> GetChatMenuButton(GetChatMenuButton getChatMenuButton, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the default administrator rights requested by the bot when it's added as an
    /// administrator to groups or channels. These rights will be suggested to users, but they are are free to
    /// modify the list before adding the bot.
    /// </summary>
    /// <param name="setMyDefaultAdministratorRights">Permissions that should be set.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetMyDefaultAdministratorRights(
        SetMyDefaultAdministratorRights setMyDefaultAdministratorRights,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the current default administrator rights of the bot.
    /// </summary>
    /// <param name="getMyDefaultAdministratorRights">Determine which default rights should be returned.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns ChatAdministratorRights on success.</returns>
    Task<ChatAdministratorRights> GetMyDefaultAdministratorRights(
        GetMyDefaultAdministratorRights getMyDefaultAdministratorRights,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to create a link for an invoice.
    /// </summary>
    /// <param name="createInvoiceLink">Metadata for the invoice</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the created invoice link as String on success.</returns>
    Task<string> CreateInvoiceLink(CreateInvoiceLink createInvoiceLink, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get information about custom emoji stickers by their identifiers.
    /// </summary>
    /// <param name="getCustomEmojiStickers">Sticker ids to get</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns an Array of Sticker objects.</returns>
    Task<Sticker[]> GetCustomEmojiStickers(GetCustomEmojiStickers getCustomEmojiStickers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to create a topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// </summary>
    /// <param name="createForumTopic">Information of the topic to create</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns information about the created topic as a <see cref="ForumTopic"/> object.</returns>
    Task<ForumTopic> CreateForumTopic(CreateForumTopic createForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to create a topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// </summary>
    /// <param name="editForumTopic">Information of the topic to edit</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns information about the created topic as a <see cref="ForumTopic"/> object.</returns>
    Task<ForumTopic> EditForumTopic(EditForumTopic editForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to close an open topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights,
    /// unless it is the creator of the topic.
    /// </summary>
    /// <param name="closeForumTopic">Forum topic to close</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> CloseForumTopic(CloseForumTopic closeForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to reopen a closed topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights,
    /// unless it is the creator of the topic.
    /// </summary>
    /// <param name="reopenForumTopic">Forum topic to reopen</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> ReopenForumTopic(ReopenForumTopic reopenForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to delete a forum topic along with all its messages in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_delete_messages administrator rights.
    /// </summary>
    /// <param name="deleteForumTopic">Forum topic to delete</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteForumTopic(DeleteForumTopic deleteForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to clear the list of pinned messages in a forum topic.
    /// The bot must be an administrator in the chat for this to work and must have the can_pin_messages administrator right in
    /// the supergroup.
    /// </summary>
    /// <param name="unpinAllForumTopicMessages">MessageThreadId to unpin all messages</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnpinAllForumTopicMessages(
        UnpinAllForumTopicMessages unpinAllForumTopicMessages,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get custom emoji stickers, which can be used as a forum topic icon by any user. Requires no parameters.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns an Array of Sticker objects.</returns>
    Task<Sticker[]> GetForumTopicIconStickers(CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to edit the name of the 'General' topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have can_manage_topics administrator rights.
    /// </summary>
    /// <param name="editGeneralForumTopic">Data to edit the general forum topic</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> EditGeneralForumTopic(EditGeneralForumTopic editGeneralForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to close an open 'General' topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// </summary>
    /// <param name="closeGeneralForumTopic">General Forum Topic to close</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> CloseGeneralForumTopic(CloseGeneralForumTopic closeGeneralForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to reopen a closed 'General' topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// The topic will be automatically unhidden if it was hidden.
    /// </summary>
    /// <param name="reopenGeneralForumTopic">General forum topic to reopen</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> ReopenGeneralForumTopic(ReopenGeneralForumTopic reopenGeneralForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to hide the 'General' topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// The topic will be automatically closed if it was open.
    /// </summary>
    /// <param name="hideGeneralForumTopic">General Forum topic to hide</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> HideGeneralForumTopic(HideGeneralForumTopic hideGeneralForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to unhide the 'General' topic in a forum supergroup chat.
    /// The bot must be an administrator in the chat for this to work and must have the can_manage_topics administrator rights.
    /// </summary>
    /// <param name="unhideGeneralForumTopic">General Forum topic to unhide</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnhideGeneralForumTopic(UnhideGeneralForumTopic unhideGeneralForumTopic, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the bot's description, which is shown in the chat with the bot if the chat is empty.
    /// </summary>
    /// <param name="setMyDescription">Description to be set</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetMyDescription(SetMyDescription setMyDescription, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the current bot description for the given user language.
    /// </summary>
    /// <param name="getMyDescription">Language to get the bot description for</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns BotDescription on success.</returns>
    Task<BotDescription> GetMyDescription(GetMyDescription getMyDescription, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the bot's short description, which is shown on the bot's profile page and is sent together
    /// with the link when users share the bot.
    /// </summary>
    /// <param name="setMyShortDescription">Language to set the short bot description for</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetMyShortDescription(SetMyShortDescription setMyShortDescription, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the current bot short description for the given user language.
    /// </summary>
    /// <param name="getMyShortDescription">Language to get the short bot description for</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns <see cref="BotShortDescription"/> on success.</returns>
    Task<BotShortDescription> GetMyShortDescription(
        GetMyShortDescription getMyShortDescription,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to set the thumbnail of a custom emoji sticker set.
    /// </summary>
    /// <param name="setCustomEmojiStickerSetThumbnail">Update info for the sticker set</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetCustomEmojiStickerSetThumbnail(
        SetCustomEmojiStickerSetThumbnail setCustomEmojiStickerSetThumbnail,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to set the title of a created sticker set.
    /// </summary>
    /// <param name="setStickerSetTitle">Update info for the sticker set</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerSetTitle(SetStickerSetTitle setStickerSetTitle, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to delete a sticker set that was created by the bot.
    /// </summary>
    /// <param name="deleteStickerSet">Name of the sticker set to be deleted</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteStickerSet(DeleteStickerSet deleteStickerSet, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the list of emoji assigned to a regular or custom emoji sticker.
    /// The sticker must belong to a sticker set created by the bot.
    /// </summary>
    /// <param name="setStickerEmojiList">Emojis to set for a sticker</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerEmojiList(SetStickerEmojiList setStickerEmojiList, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change search keywords assigned to a regular or custom emoji sticker.
    /// The sticker must belong to a sticker set created by the bot.
    /// </summary>
    /// <param name="setStickerKeywords">Keywords to set for a sticker</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerKeywords(SetStickerKeywords setStickerKeywords, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the mask position of a mask sticker.
    /// The sticker must belong to a sticker set that was created by the bot.
    /// </summary>
    /// <param name="setStickerMaskPosition">Mask position to set for a sticker</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetStickerMaskPosition(SetStickerMaskPosition setStickerMaskPosition, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the bot's name.
    /// </summary>
    /// <param name="setMyName">Botname to set</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>True on success.</returns>
    Task<bool> SetMyName(SetMyName setMyName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the current bot name for the given user language.
    /// </summary>
    /// <param name="getMyName">Botname to get</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns <see cref="BotName"/> on success.</returns>
    Task<BotName> GetMyName(GetMyName getMyName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to clear the list of pinned messages in a General forum topic.
    /// The bot must be an administrator in the chat for this to work and must have the can_pin_messages administrator right in the supergroup.
    /// </summary>
    /// <param name="unpinAllGeneralForumTopicMessages">ChatId to unpin all general forum topic messages in </param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> UnpinAllGeneralForumTopicMessages(
        UnpinAllGeneralForumTopicMessages unpinAllGeneralForumTopicMessages,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to change the chosen reactions on a message. Service messages can't be reacted to.
    /// Automatically forwarded messages from a channel to its discussion group have the same available reactions as messages in the channel.
    /// In albums, bots must react to the first message.
    /// </summary>
    /// <param name="messageReaction">MessageReaction to set on the message</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> SetMessageReaction(SetMessageReaction messageReaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to delete multiple messages simultaneously.
    /// If some of the specified messages can't be found, they are skipped.
    /// </summary>
    /// <param name="deleteMessages">MessageIds to delete</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> DeleteMessages(DeleteMessages deleteMessages, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to forward multiple messages of any kind. If some of the specified messages can't be found or forwarded, they are skipped.
    /// Service messages and messages with protected content can't be forwarded. Album grouping is kept for forwarded messages.
    /// </summary>
    /// <param name="forwardMessages">MessageIds to forward</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> ForwardMessages(ForwardMessages forwardMessages, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get the list of boosts added to a chat by a user. Requires administrator rights in the chat.
    /// </summary>
    /// <param name="getUserChatBoosts">UserChatBoosts to get</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns <see cref="UserChatBoosts"/> on success.</returns>
    Task<UserChatBoosts> GetUserChatBoosts(GetUserChatBoosts getUserChatBoosts, CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to get information about the connection of the bot with a business account.
    /// Returns a <see cref="BusinessConnection"/> object on success.
    /// </summary>
    /// <param name="getBusinessConnection">BusinessConnection to get</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns <see cref="BusinessConnection"/> on success.</returns>
    Task<BusinessConnection> GetBusinessConnection(
        GetBusinessConnection getBusinessConnection,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Use this method to replace an existing sticker in a sticker set with a new one.
    /// The method is equivalent to calling <see cref="ITelegramBot.DeleteStickerFromSet"/>, then <see cref="ITelegramBot.AddStickerToSet"/>, then <see cref="ITelegramBot.SetStickerPositionInSet"/>.
    /// </summary>
    /// <param name="replaceStickerInSet">Information about the Sticker to replace</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns True on success.</returns>
    Task<bool> ReplaceStickerInSet(ReplaceStickerInSet replaceStickerInSet, CancellationToken cancellationToken = default);
}
