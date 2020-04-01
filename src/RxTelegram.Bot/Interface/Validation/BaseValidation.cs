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
        private IValidationResult _validationResult;

        private IValidationResult ValidationResult
        {
            get
            {
                if (_validationResult == null)
                {
                    _validationResult = Validate();
                }

                return _validationResult;
            }
        }

        protected abstract IValidationResult Validate();

        public bool IsValid() => ValidationResult.IsValid();

        public List<ValidationError> Errors => ValidationResult.Errors();
    }
}
