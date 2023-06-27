using RxTelegram.Bot.Utils;
// ReSharper disable UnusedMember.Global

namespace RxTelegram.Bot.Exceptions;

public enum ErrorCode
{
    [Regex("chat not found")]
    ChatNotFound = 1000,

    [Regex("user not found")]
    UserNotFound = 2000,

    [Regex("USER_ID_INVALID")]
    InvalidUserId = 3000,

    [Regex("QUERY_ID_INVALID")]
    InvalidQueryId = 4000,

    [Regex("phone number can be requested in a private chats only"),]
    ContactRequest = 5000,

    [Regex("bot can't initiate conversation with a user")]
    ChatNotInitiated = 6000,

    [Regex("message is not modified")]
    MessageIsNotModified = 7000,

    #region Stickers

    [Regex("sticker set name invalid")]
    InvalidStickerSetName = 8000,

    [Regex("invalid sticker emojis")]
    InvalidStickerEmojis = 9001,

    [Regex("STICKER_PNG_DIMENSIONS")]
    InvalidStickerDimensions = 9002,

    [Regex("sticker set name is already occupied")]
    StickerSetNameExists = 9003,

    [Regex("STICKERSET_NOT_MODIFIED")]
    StickerSetNotModified = 9004,

    #endregion

    #region Games

    [Regex("GAME_SHORTNAME_INVALID", "game_short_name is empty", "wrong game short name specified")]
    InvalidGameShortName = 6000,

    #endregion
}