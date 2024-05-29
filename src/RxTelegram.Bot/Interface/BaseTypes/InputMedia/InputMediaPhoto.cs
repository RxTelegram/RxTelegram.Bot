using System;
using System.Collections.Generic;
using System.IO;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

public class InputMediaPhoto : BaseInputMedia
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    public override InputMediaTypes Type { get; set; } = InputMediaTypes.Photo;

    /// <summary>
    /// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold,
    /// italic, fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    /// List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public IEnumerable<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True if the photo needs to be covered with a spoiler Animation
    /// </summary>
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Optional. True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    public InputMediaPhoto(string fileId) : base(fileId)
    {
    }

    public InputMediaPhoto(Uri uri) : base(uri)
    {
    }

    public InputMediaPhoto(Stream stream, string fileName = default) : base(stream, fileName)
    {
    }
}
