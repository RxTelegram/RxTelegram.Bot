using System;

namespace RxTelegram.Bot.Validation;

[AttributeUsage(AttributeTargets.Field)]
public class ValidationErrorsStringAttribute : Attribute
{
    public string Reason { get; }

    public ValidationErrorsStringAttribute(string reason) => Reason = reason;
}
