using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

/// <summary>
/// Use this method to edit live location messages. A location can be edited until its live_period expires or editing is explicitly
/// disabled by a call to stopMessageLiveLocation. On success, if the edited message was sent by the bot, the edited Message is
/// returned, otherwise True is returned.
/// </summary>
public class EditMessageLiveLocation : BaseRequest
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message to be edited was sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Required if inline_message_id is not specified. Identifier of the message to edit
    /// </summary>
    public int? MessageId { get; set; }

    /// <summary>
    /// Required if chat_id and message_id are not specified. Identifier of the inline message
    /// </summary>
    public string InlineMessageId { get; set; }

    /// <summary>
    /// Required
    /// Latitude of new location
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Required
    /// Longitude of new location
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// New period in seconds during which the location can be updated, starting from the message send date.
    /// If 0x7FFFFFFF is specified, then the location can be updated forever.
    /// Otherwise, the new value must not exceed the current live_period by more than a day, and the live location expiration date must remain within the next 90 days.
    /// If not specified, then live_period remains unchanged
    /// </summary>
    public int LivePeriod { get; set; } = 0x7FFFFFFF;

    /// <summary>
    /// The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public double? HorizontalAccuracy { get; set; }

    /// <summary>
    /// Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    public int? ProximityAlertRadius { get; set; }

    /// <summary>
    /// Optional
    /// A JSON-serialized object for a new inline keyboard.
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
