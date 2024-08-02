using RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputPaidMedia;

/// <summary>
/// The paid media to send is a photo.
/// </summary>
public class BaseInputPaidMediaPhoto: BaseInputPaidMedia
{
    /// <summary>
    /// Type of the media, must be photo
    /// </summary>
    public override InputPaidMediaTypes Type { get; set; } = InputPaidMediaTypes.Photo;

    /// <summary>
    /// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended),
    /// pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://{file_attach_name}” to upload a new one
    /// using multipart/form-data under {file_attach_name} name.
    /// </summary>
    public string Media { get; set; }
}
