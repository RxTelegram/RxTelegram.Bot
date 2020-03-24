using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TelegramInterface.BaseTypes.Requests;
using TelegramInterface.BaseTypes.Requests.Attachments;

namespace Core.Utils
{
    public class Reflection
    {
        public static IEnumerable<InputFile> FindInputFileRecursive(object value)
        {
            var type = value.GetType();

            if (!type.IsClass || type == typeof(string))
            {
                yield break;
            }

            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    .Where(property => !property.GetIndexParameters()
                                                                .Any())
                                    .Select(property => property.GetValue(value, null))
                                    .Where(valueObject => valueObject != null)
                                    .ToList();
            foreach (var valueObject in propertyInfos)
            {
                switch (valueObject)
                {
                    case InputFile inputFile:
                        yield return inputFile;
                        continue;
                    case IEnumerable enumerable:
                    {
                        foreach (var item in enumerable)
                        {
                            if (item is InputFile itemInputFile)
                            {
                                yield return itemInputFile;
                                continue;
                            }

                            foreach (var o in FindInputFileRecursive(item))
                            {
                                yield return o;
                            }
                        }

                        break;
                    }
                    default:
                    {
                        foreach (var o in FindInputFileRecursive(valueObject))
                        {
                            yield return o;
                        }

                        break;
                    }
                }
            }
        }
    }
}
