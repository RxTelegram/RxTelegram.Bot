using RxTelegram.Bot.Interface.BaseTypes.InputMedia.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes.InputMedia;

public interface InputProfilePhoto
{
    /// <summary>
    ///     Type of the result
    /// </summary>
    public abstract InputProfilePhotoTypes Type { get; set; }
}
