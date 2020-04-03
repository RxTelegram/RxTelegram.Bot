using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments
{
    public class SendPhoto : BaseSend
    {
        /// <summary>
        /// Photo to send
        /// </summary>
        public InputFile Photo { get; set; }

        /// <summary>
        /// Photo caption (may also be used when resending photos by file_id), 0-1024 characters after entities parsing
        /// </summary>
        public string Caption { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
