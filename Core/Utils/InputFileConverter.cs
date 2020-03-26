using System;
using Newtonsoft.Json;
using TelegramInterface.BaseTypes.Requests.Attachments;

namespace Core.Utils
{
    public class InputFileConverter : JsonConverter<InputFile>
    {
        public override bool CanRead { get; } = false;

        public override void WriteJson(JsonWriter writer, InputFile value, JsonSerializer serializer)
        {
            if (!string.IsNullOrWhiteSpace(value.Value))
            {
                writer.WriteValue(value.Value);
            }
            else
            {
                if (writer is MultiPartJsonWriter jsonWriter)
                {
                    jsonWriter.WriteStream(value.Stream, value.FileName);
                }
                else
                {
                    writer.WriteNull();
                }
            }
        }

        public override InputFile ReadJson(
            JsonReader reader,
            Type objectType,
            InputFile existingValue,
            bool hasExistingValue,
            JsonSerializer serializer) => throw new NotImplementedException();
    }
}
