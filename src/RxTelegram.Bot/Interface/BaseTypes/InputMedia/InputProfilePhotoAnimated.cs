namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

/// <summary>
/// An animated profile photo in the MPEG4 format.
/// </summary>
public class InputProfilePhotoAnimated : InputProfilePhoto
{
    /// <summary>
    ///     Type of the result
    /// </summary>
    public InputProfilePhotoTypes Type { get; set; } = InputProfilePhotoTypes.Animated;

    /// <summary>
    /// The animated profile photo. Profile photos can't be reused and can only be uploaded as a new file,
    /// so you can pass “attach://<file_attach_name>” if the photo was uploaded using multipart/form-data under <file_attach_name>.
    /// </summary>
    public string Animation { get; set; }

    /// <summary>
    /// Optional.
    /// Timestamp in seconds of the frame that will be used as the static profile photo.
    /// Defaults to 0.0.
    /// </summary>
    public double FrameTimestamp { get; set; } = 0.0;
}
