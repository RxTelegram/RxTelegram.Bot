using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendLocation : BaseRequest, IProtectContent
    {
        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public int MessageThreadId { get; set; }

        /// <summary>
        /// Required
        /// Latitude of the location
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Required
        /// Longitude of the location
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The radius of uncertainty for the location, measured in meters; 0-1500
        /// </summary>
        public double? HorizontalAccuracy { get; set; }

        /// <summary>
        /// Optional
        /// Period in seconds for which the location will be updated (see Live Locations, should be between 60 and 86400.
        /// </summary>
        public int? LivePeriod { get; set; }

        /// <summary>
        /// For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
        /// </summary>
        public int? Heading { get; set; }

        /// <summary>
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
        /// Must be between 1 and 100000 if specified.
        /// </summary>
        public int? ProximityAlertRadius { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        public IReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Pass True, if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
