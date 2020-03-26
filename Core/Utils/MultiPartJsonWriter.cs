using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Utils
{
    public class MultiPartJsonWriter : JTokenWriter
    {
        private readonly MultipartFormDataContent _multipartFormDataContent;
        private string _propertyName;
        private int _depth;
        public bool StreamContent { get; private set; }

        public MultiPartJsonWriter(MultipartFormDataContent multipartFormDataContent)
        {
            _multipartFormDataContent = multipartFormDataContent;
        }

        public void WriteStream(Stream stream, string filename)
        {
            StreamContent = true;
            filename = filename ?? Guid.NewGuid().ToString();
            if (_depth > 1)
            {
                base.WriteValue($"attach://{filename}");
                _multipartFormDataContent.Add(new StreamContent(stream), filename, filename);
            }
            else
            {
                _multipartFormDataContent.Add(new StreamContent(stream), _propertyName, filename);
                base.WriteNull();
            }
        }

        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(name);
            if (_depth == 1)
            {
                _propertyName = name;
            }
        }

        public override void WriteNull()
        {
            base.WriteNull();
            WriteValueElement("null");
        }

        public override void WriteValue(DateTime value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString(CultureInfo.InvariantCulture));
        }

        public override void WriteValue(DateTimeOffset value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString(CultureInfo.InvariantCulture));
        }

        public override void WriteValue(Guid value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(TimeSpan value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(Uri value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(string value)
        {
            base.WriteValue(value);
            WriteValueElement(value);
        }

        public override void WriteValue(int value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(long value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(short value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(byte value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(bool value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(char value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString());
        }

        public override void WriteValue(decimal value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString(CultureInfo.InvariantCulture));
        }

        public override void WriteValue(double value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString(CultureInfo.InvariantCulture));
        }

        public override void WriteValue(float value)
        {
            base.WriteValue(value);
            WriteValueElement(value.ToString(CultureInfo.InvariantCulture));
        }

        private void WriteValueElement(string value)
        {
            if (_depth != 1 || _propertyName == null)
            {
                return;
            }

            _multipartFormDataContent.Add(new StringContent(value), _propertyName);
            _propertyName = null;
        }

        public override void WriteStartArray()
        {
            base.WriteStartArray();
            _depth++;
        }

        public override void WriteStartObject()
        {
            base.WriteStartObject();
            _depth++;
        }

        public override void WriteStartConstructor(string name)
        {
            base.WriteStartConstructor(name);
            _depth++;
        }

        public override void WriteEndArray()
        {
            base.WriteEndArray();
            if (_depth == 2)
            {
                _multipartFormDataContent.Add(new StringContent(CurrentToken.ToString(Formatting.None)), _propertyName);
            }
            _depth--;
        }

        public override void WriteEndObject()
        {
            base.WriteEndObject();
            if (_depth == 2)
            {
                _multipartFormDataContent.Add(new StringContent(CurrentToken.ToString(Formatting.None)), _propertyName);
            }
            _depth--;
        }

        public override void WriteEndConstructor()
        {
            _depth--;
            base.WriteEndConstructor();
        }

        public override void Flush()
        {
        }
    }
}
