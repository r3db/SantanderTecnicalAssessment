using System;
using Newtonsoft.Json;

namespace Santander
{
    public class ItemTypeJsonConverter : JsonConverter<ItemType>
    {
        public override ItemType ReadJson(JsonReader reader, Type objectType, ItemType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.Value)
            {
                case "job":     return ItemType.Job;
                case "story":   return ItemType.Story;
                case "comment": return ItemType.Comment;
                case "poll":    return ItemType.Poll;
                case "pollopt": return ItemType.Pollopt;
                default:        throw new ArgumentException();
            }
        }

        public override void WriteJson(JsonWriter writer, ItemType value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}