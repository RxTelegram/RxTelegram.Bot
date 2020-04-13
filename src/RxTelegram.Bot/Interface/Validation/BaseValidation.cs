using System.Collections.Generic;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Validation
{
    public abstract class BaseValidation
    {
        private IValidationResult _validationResult;

        private IValidationResult ValidationResult => _validationResult ?? (_validationResult = Validate());

        protected abstract IValidationResult Validate();

        public string GetPath() => ValidationResult.Path;

        public void SetPath(string value) => ValidationResult.Path = value;

        public bool IsValid() => ValidationResult.IsValid();

        public List<ValidationError> Errors => ValidationResult.Errors;
    }
}
