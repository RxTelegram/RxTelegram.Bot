using System.Collections.Generic;

namespace RxTelegram.Bot.Validation
{
    public class ValidationError
    {
        public ValidationError(List<string> propertyName, ValidationErrors fieldRequired)
        {
            PropertyNames = propertyName;
            Error = fieldRequired.Reason();
        }

        public ValidationError(List<string> propertyName, string error)
        {
            PropertyNames = propertyName;
            Error = error;
        }

        public ValidationError(string propertyName, ValidationErrors fieldRequired)
        {
            PropertyNames.Add(propertyName);
            Error = fieldRequired.Reason();
        }

        public ValidationError(string propertyName, string error)
        {
            PropertyNames.Add(propertyName);
            Error = error;
        }

        private string Error { get; }

        public void AddPath(string value) => Path.Insert(0, value);

        private List<string> PropertyNames { get; } = new List<string>();

        private List<string> Path { get; } = new List<string>();


        public override string ToString() => BuildMessage();

        public string GetMessage => BuildMessage();

        private string BuildMessage()
        {
            var path = string.Join(".", Path);
            var properties = string.Empty;

            for (var index = 0; index < PropertyNames.Count; index++)
            {
                var propertyName = PropertyNames[index];
                if (path != string.Empty)
                {
                    path += ".";
                }
                properties += path + propertyName;
                if (index < PropertyNames.Count-1)
                {
                    properties += ", ";
                }
            }

            return $"({properties}): \"{Error}\"";
        }
    }
}
