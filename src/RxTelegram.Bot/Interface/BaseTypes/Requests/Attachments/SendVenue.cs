using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
/// Use this method to send information about a venue. On success, the sent Message is returned.
/// </summary>
public class SendVenue : BaseRequest, IProtectContent
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int MessageThreadId { get; set; }

    /// <summary>
    /// Required
    /// Latitude of the venue
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Required
    /// Longitude of the venue
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Required
    /// Name of the venue
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Required
    /// Address of the venue
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Optional
    /// Foursquare identifier of the venue
    /// </summary>
    public string FoursquareId { get; set; }

    /// <summary>
    /// Optional
    /// Foursquare type of the venue, if known.
    /// (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    public string FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    public string GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// </summary>
    public string GooglePlaceType { get; set; }

    /// <summary>
    /// Optional
    /// Sends the message silently. Users will receive a notification with no sound.
    /// </summary>
    public bool? DisableNotification { get; set; }

    /// <summary>
    /// Description of the message to reply to
    /// </summary>
    public ReplyParameters ReplyParameters { get; set; }

    /// <summary>
    /// Optional
    /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
    /// </summary>
    public IReplyMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Unique identifier of the message effect to be added to the message; for private chats only
    /// </summary>
    public string MessageEffectId { get; set; }

    /// <summary>
    /// Protects the contents of the sent message from forwarding and saving
    /// </summary>
    public bool? ProtectContent { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
