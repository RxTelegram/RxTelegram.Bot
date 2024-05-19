using RxTelegram.Bot.Interface.Stickers;

namespace RxTelegram.Bot.Interface.Business;

public class BusinessIntro
{
    /// <summary>
    /// Optional. Title text of the business intro
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Message text of the business intro
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Optional. Sticker of the business intro
    /// </summary>
    public Sticker Sticker { get; set; }
}
