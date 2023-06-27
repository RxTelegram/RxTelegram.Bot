using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Users;

public class GetUserProfilePhotos : BaseValidation
{
    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Sequential number of the first photo to be returned. By default, all photos are returned.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.
    /// </summary>
    public int Limit { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}