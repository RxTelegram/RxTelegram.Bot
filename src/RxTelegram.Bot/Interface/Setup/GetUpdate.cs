using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Setup
{
    public class GetUpdate : BaseValidation
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public int? Timeout { get; set; }

        public IEnumerable<UpdateType> AllowedUpdates { get; set; }

        protected override IValidationResult Validate() => new ValidationResult<GetUpdate>(this);
    }
}
