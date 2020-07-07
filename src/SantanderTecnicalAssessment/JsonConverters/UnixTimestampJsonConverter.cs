using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Santander
{
    public class UnixTimestampJsonConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime _start = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return _start.AddSeconds((long)reader.Value).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}