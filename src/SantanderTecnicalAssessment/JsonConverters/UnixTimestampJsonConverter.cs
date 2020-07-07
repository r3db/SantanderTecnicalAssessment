using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantanderTecnicalAssessment
{
    public class UnixTimestampJsonConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime _start = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return _start.AddSeconds(reader.GetInt64()).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}