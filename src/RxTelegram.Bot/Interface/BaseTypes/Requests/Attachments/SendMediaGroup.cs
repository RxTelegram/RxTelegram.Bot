using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.InputMedia;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendMediaGroup : BaseRequest
    {
        /// <summary>
        /// A JSON-serialized array describing photos and videos to be sent, must include 2–10 items
        /// </summary>
        public IEnumerable<BaseInputMedia> Media { get; set; }

        /// <summary>
        /// Sends the messages silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// If the messages are a reply, ID of the original message
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        protected override void Validate() => throw new System.NotImplementedException();
    }
}
