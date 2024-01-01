using System;
using System.IO;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

public abstract class BaseInputMedia : IMultiTypeClassByType<InputMediaTypes>
{
    protected BaseInputMedia(string fileId) => Media = new InputFile(fileId);

    protected BaseInputMedia(Uri uri) => Media = new InputFile(uri);

    protected BaseInputMedia(Stream stream, string fileName = default) => Media = new InputFile(stream, fileName);

    /// <summary>
    ///     Type of the result
    /// </summary>
    public abstract InputMediaTypes Type { get; set; }

    /// <summary>
    ///     File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended),
    ///     pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://{file_attach_name}” to
    ///     upload a new one using multipart/form-data under {file_attach_name} name.
    ///     https://core.telegram.org/bots/api#sending-files
    /// </summary>
    public InputFile Media { get; }
}
