using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Validation
{
    public abstract class BaseValidation
    {
        [JsonIgnore]
        protected ValidationResult Validation { get; } = new ValidationResult();

        protected abstract void Validate();

        public bool IsValid()
        {
            Validate();
            return Validation.ValidationErrors.Any();
        }

        public List<ValidationError> ValidationErrors => Validation.ValidationErrors;
    }
}
