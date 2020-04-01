using System.Collections.Generic;

namespace RxTelegram.Bot.Validation
{
    public interface IValidationResult
    {
        List<ValidationError> Errors();

        bool IsValid();
    }
}
