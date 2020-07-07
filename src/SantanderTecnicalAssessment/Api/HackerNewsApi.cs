using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Santander
{
    public sealed class HackerNewsApi : IHackerNewsApi
    {
        private const string StoriesUri = "https://hacker-news.firebaseio.com/v0/beststories.json";
        private const string ItemUriFormat = "https://hacker-news.firebaseio.com/v0/item/{0}.json";

        //private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IDictionary<int, Item> _cachedItems = new Dictionary<int, Item>();

        // Note: As most of .Net Core this call is not thread-safe!
        // Note: I could make this parallel, but we're not processor bound, we are IO bound!
        public async Task<IEnumerable<Item>> GetBestStories()
        {
            var result = new List<Item>();
            // Note: I could cache this request, but I'm assuming it's contents change quite often, more investigation needed.
            var storiesTask = _httpClient.GetStringAsync(StoriesUri);
            var stories = JsonConvert.DeserializeObject<IList<int>>(await storiesTask);

            foreach (var identifier in stories)
            {
                if (_cachedItems.ContainsKey(identifier) == false)
                {
                    var itemTask = _httpClient.GetStringAsync(string.Format(ItemUriFormat, identifier));
                    // Note: I'm assuming we always receive something.
                    var item = JsonConvert.DeserializeObject<Item>(await itemTask);
                    _cachedItems.Add(identifier, item);
                }

                result.Add(_cachedItems[identifier]);
            }

            return result;
        }

        public async Task<IEnumerable<Story>> GetBestStoriesOrderedByScore()
        {
            return (await GetBestStories()).OrderBy(x => x.Score).Take(20).Select(x => new Story
            {
                Title        = x.Title,
                Uri          = x.Url,
                PostedBy     = x.By,
                Time         = x.Time,
                Score        = x.Score,
                CommentCount = x.Kids.Count()
            });
        }
    }
}