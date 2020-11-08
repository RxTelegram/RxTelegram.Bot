using System.Linq;

namespace RxTelegram.Bot.Validation
{
    public static class ValidationsErrorExtension
    {
        public static string Reason(this ValidationErrors enumVal)
        {
            var memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            var attributes = memInfo[0]
                             .GetCustomAttributes(typeof(ValidationErrorsStringAttribute), false)
                             .Cast<ValidationErrorsStringAttribute>();
            return attributes.FirstOrDefault()?.Reason;
        }
    }
}
