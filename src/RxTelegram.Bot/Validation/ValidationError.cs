namespace RxTelegram.Bot.Interface.Validation
{
    public class ValidationError
    {
        public ValidationError(string propertyName, ValidationErrors fieldRequired)
        {
            PropertyName = propertyName;
            Error = fieldRequired.Reason();
        }

        public ValidationError(string propertyName, string error)
        {
            PropertyName = propertyName;
            Error = error;
        }

        public string PropertyName { get; }

        public string Error { get; }

        public override string ToString() => $"({PropertyName}): \"{Error}\"";

        public string GetMessage => $"({PropertyName}): \"{Error}\"";
    }
}
