using System.Collections.Generic;
using System.Linq;

namespace RxTelegram.Bot.Validation
{
    public class ValidationResult
    {
        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();

        public bool IsValid() => !ValidationErrors.Any();
    }
}
