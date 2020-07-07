using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Santander
{
    public sealed class Item
    {
        public int Id { get; set; }
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Score { get; set; }
        [JsonConverter(typeof(UnixTimestampJsonConverter))]
        public DateTime Time { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(ItemTypeJsonConverter))]
        public ItemType Type { get; set; }
        public string Url { get; set; }
        public IEnumerable<int> Kids { get; set; }
    }
}