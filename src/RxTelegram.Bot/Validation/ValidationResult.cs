using System.Collections.Generic;
using System.Linq;

namespace RxTelegram.Bot.Validation
{
    public class ValidationResult<T> : IValidationResult
    {
        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();

        public string Path { get; set; }

        public T Value { get; }

        public ValidationResult(T value)
        {
            Value = value;
            this.ValidateNested();
        }

        public List<ValidationError> Errors => ValidationErrors;

        public bool IsValid() => !ValidationErrors.Any();
    }
}
