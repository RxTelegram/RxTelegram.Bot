using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendLocation : BaseRequest
    {
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
        /// Optional
        /// Period in seconds for which the location will be updated (see Live Locations, should be between 60 and 86400.
        /// </summary>
        public int? LivePeriod { get; set; }

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
    }
}
