using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.Stickers.Enums;

namespace RxTelegram.Bot.Interface.Stickers;

/// <summary>
/// This object describes a sticker to be added to a sticker set.
/// </summary>
public class InputSticker
{
    /// <summary>
    /// The added sticker. Pass a file_id as a String to send a file that already exists on the Telegram servers,
    /// pass an HTTP URL as a String for Telegram to get a file from the Internet, upload a new one using multipart/form-data,
    /// or pass “attach:// file_attach_name ” to upload a new one using multipart/form-data under file_attach_name name.
    /// Animated and video stickers can't be uploaded via HTTP URL.
    /// </summary>
    public InputFile Sticker { get; set; }

    /// <summary>
    /// Format of the added sticker, must be one of “static” for a .WEBP or .PNG image, “animated” for a .TGS animation, “video” for a WEBM video
    /// </summary>
    public StickerFormat Format { get; set; }

    /// <summary>
    /// List of 1-20 emoji associated with the sticker
    /// </summary>
    public List<string> EmojiList { get; set; }

    /// <summary>
    /// Optional.
    /// Position where the mask should be placed on faces. For “mask” stickers only.
    /// </summary>
    public MaskPosition MaskPosition { get; set; }

    /// <summary>
    /// Optional.
    /// List of 0-20 search keywords for the sticker with total length of up to 64 characters.
    /// For “regular” and “custom_emoji” stickers only.
    /// </summary>
    public List<string> Keywords { get; set; }
}
