using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantanderTecnicalAssessment
{
    public class ItemTypeJsonConverter : JsonConverter<ItemType>
    {
        public override ItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.GetString())
            {
                case "job":     return ItemType.Job;
                case "story":   return ItemType.Story;
                case "comment": return ItemType.Comment;
                case "poll":    return ItemType.Poll;
                case "pollopt": return ItemType.Pollopt;
                default:        throw new ArgumentException();
            }
        }

        public override void Write(Utf8JsonWriter writer, ItemType value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}