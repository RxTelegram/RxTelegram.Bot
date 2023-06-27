using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Exceptions;

[Serializable]
public class RequestValidationException : Exception
{
    private static readonly string DefaultMessage =
        $"Validation of the request faild. Please have a look at the {nameof(ValidationErrors)} property to see," +
        " which properties have invalid values";

    public List<ValidationError> ValidationErrors { get; }

    public RequestValidationException(List<ValidationError> validationErrors) : base(DefaultMessage) => ValidationErrors = validationErrors;

    protected RequestValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
        base(serializationInfo, streamingContext)
    {
    }
}
