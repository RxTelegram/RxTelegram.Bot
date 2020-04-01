namespace RxTelegram.Bot.Validation
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

        private string PropertyName { get; }

        private string Error { get; }

        public override string ToString() => $"({PropertyName}): \"{Error}\"";

        public string GetMessage => $"({PropertyName}): \"{Error}\"";
    }
}
