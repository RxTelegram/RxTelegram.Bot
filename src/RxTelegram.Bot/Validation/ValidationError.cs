using System.Collections.Generic;

namespace RxTelegram.Bot.Validation
{
    /// <summary>
    /// Indicates an invalid configuration in telegram bot request. This allows for client side validation of requests and reduces network
    /// traffic and delay.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Constructor for a nested invalid property with error type
        /// </summary>
        /// <param name="propertyName">Path to the invalid property</param>
        /// <param name="fieldRequired">Type of validation error</param>
        public ValidationError(List<string> propertyName, ValidationErrors fieldRequired)
        {
            PropertyNames = propertyName;
            Error = fieldRequired.Reason();
        }

        /// <summary>
        /// Constructor for a nested invalid property with error message
        /// </summary>
        /// <param name="propertyName">Path to the invalid property</param>
        /// <param name="error">Error message as string</param>
        public ValidationError(List<string> propertyName, string error)
        {
            PropertyNames = propertyName;
            Error = error;
        }

        /// <summary>
        /// Constructor for a top level invalid property with error type
        /// </summary>
        /// <param name="propertyName">Name of the invalid property</param>
        /// <param name="fieldRequired">Type of the validation error</param>
        public ValidationError(string propertyName, ValidationErrors fieldRequired)
        {
            PropertyNames.Add(propertyName);
            Error = fieldRequired.Reason();
        }

        /// <summary>
        /// Constructor for a top level invalid property with error message
        /// </summary>
        /// <param name="propertyName">Name of the invalid property</param>
        /// <param name="error">Error message as string</param>
        public ValidationError(string propertyName, string error)
        {
            PropertyNames.Add(propertyName);
            Error = error;
        }

        private string Error { get; }

        /// <summary>
        /// Adds a Path for a nested property
        /// </summary>
        /// <param name="value"></param>
        public void AddPath(string value) => Path.Insert(0, value);

        private List<string> PropertyNames { get; } = new List<string>();

        private List<string> Path { get; } = new List<string>();


        /// <summary>
        /// Generate a error Message
        /// </summary>
        /// <returns></returns>
        public override string ToString() => BuildMessage();

        /// <summary>
        /// Generate a error Message
        /// </summary>
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
