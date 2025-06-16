using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

/// <summary>
/// A static profile photo in the .JPG format.
/// </summary>
public class InputProfilePhotoStatic : InputProfilePhoto
{
    /// <summary>
    /// Type of the profile photo, must be static
    /// </summary>
    public InputProfilePhotoTypes Type { get; set; } = InputProfilePhotoTypes.Static;

    /// <summary>
    /// The static profile photo. Profile photos can't be reused and can only be uploaded as a new file,
    /// so you can pass “attach://file_attach_name” if the photo was uploaded using multipart/form-data under file_attach_name.
    /// </summary>
    public string Photo { get; set; }
}
