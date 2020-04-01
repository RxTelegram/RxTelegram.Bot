using System.Collections.Generic;

namespace RxTelegram.Bot.Validation
{
    public class ValidationResult
    {
        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();
    }
}
