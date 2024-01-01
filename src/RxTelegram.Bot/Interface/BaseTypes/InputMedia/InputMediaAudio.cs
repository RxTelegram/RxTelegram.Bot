using System;
using System.IO;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

public class InputMediaAudio : BaseInputMedia
{
    public InputMediaAudio(string fileId) : base(fileId)
    {
    }

    public InputMediaAudio(Uri uri) : base(uri)
    {
    }

    public InputMediaAudio(Stream stream, string fileName = default) : base(stream, fileName)
    {
    }

    /// <summary>
    ///     Type of the result, must be audio
    /// </summary>
    public override InputMediaTypes Type { get; set; } = InputMediaTypes.Audio;

    /// <summary>
    ///     Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
    ///     The thumbnail should be in JPEG format and less than 200 kB in size.
    ///     A thumbnail‘s width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data.
    ///     Thumbnails can’t be reused and can be only uploaded as a new file, so you can pass “attach://{file_attach_name}” if
    ///     the thumbnail was uploaded using multipart/form-data under {file_attach_name}.
    ///     https://core.telegram.org/bots/api#sending-files
    /// </summary>
    public InputFile Thumbnail { get; set; }

    /// <summary>
    ///     Optional. Caption of the audio to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    ///     Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic,
    ///     fixed-width text or inline URLs in the media caption.
    /// </summary>
    public ParseMode ParseMode { get; set; }

    /// <summary>
    ///     Optional. Duration of the audio in seconds
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    ///     Optional. Performer of the audio
    /// </summary>
    public string Performer { get; set; }

    /// <summary>
    ///     Optional. Title of the audio
    /// </summary>
    public string Title { get; set; }
}
