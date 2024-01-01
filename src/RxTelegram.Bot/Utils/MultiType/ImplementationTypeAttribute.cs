using System;

namespace RxTelegram.Bot.Utils.MultiType;

[AttributeUsage(AttributeTargets.Field)]
public class ImplementationTypeAttribute(Type implementationType) : Attribute
{
    public Type ImplementationType { get; } = implementationType;
}
