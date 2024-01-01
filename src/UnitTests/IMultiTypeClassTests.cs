using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class IMultiTypeClassTests
{
    [Test]
    public void AllIMultiTypeClassBySourceEnums_ShouldHaveAImplementationAttribute()
    {
        var classesToValidate = Assembly.GetAssembly(typeof(BaseValidation))
                                        ?.GetTypes()
                                        .Where(myType => myType.IsClass && myType.IsAbstract)
                                        .ToList();
        Assert.That(classesToValidate, Is.Not.Null);
        foreach (var enumType in classesToValidate.Select(multiTypeBaseClass => multiTypeBaseClass.GetInterfaces())
                                                  .Select(interfaces =>
                                                              interfaces.FirstOrDefault(x => x.IsGenericType &&
                                                                                            x.GetGenericTypeDefinition() ==
                                                                                            typeof(IMultiTypeClassBySource<>)) ??
                                                              interfaces.FirstOrDefault(x => x.IsGenericType &&
                                                                                            x.GetGenericTypeDefinition() ==
                                                                                            typeof(IMultiTypeClassByType<>)))
                                                  .Where(interfaceType => interfaceType != null)
                                                  .Select(interfaceType => interfaceType.GetGenericArguments()
                                                                                        .FirstOrDefault()))
        {
            Assert.That(enumType, Is.Not.Null);
            var enumFields = Enum.GetNames(enumType);
            foreach (var enumFieldName in enumFields)
            {
                var enumField = enumType.GetMember(enumFieldName);
                var attribute = enumField[0]
                    .GetCustomAttributes(typeof(ImplementationTypeAttribute), false);
                Assert.That(attribute.FirstOrDefault(), Is.Not.Null);
            }
        }
    }
}
