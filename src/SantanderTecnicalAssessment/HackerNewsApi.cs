using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SantanderTecnicalAssessment
{
    public sealed class HackerNewsApi
    {
        private const string StoriesUri = "https://hacker-news.firebaseio.com/v0/beststories.json";
        private const string ItemUriFormat = "https://hacker-news.firebaseio.com/v0/item/{0}.json";

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IDictionary<int, Item> _cachedItems = new Dictionary<int, Item>();

        // Note: As most of .Net Core this call is not thread-safe!
        // Note: I could make this parallel, but we're not processor bound, we are IO bound!
        public async Task<IEnumerable<Item>> GetBestStories()
        {
            var result = new List<Item>();
            // Note: I could cache this request, but I'm assuming it's contents change quite often, more investigation needed.
            var storiesTask = _httpClient.GetStreamAsync(StoriesUri);
            var stories = await JsonSerializer.DeserializeAsync<IList<int>>(await storiesTask, _jsonSerializerOptions);

            foreach (var identifier in stories)
            {
                if (_cachedItems.ContainsKey(identifier) == false)
                {
                    var itemTask = _httpClient.GetStreamAsync(string.Format(ItemUriFormat, identifier));
                    // Note: I'm assuming we always receive something.
                    var item = await JsonSerializer.DeserializeAsync<Item>(await itemTask, _jsonSerializerOptions);
                    _cachedItems.Add(identifier, item);
                }

                result.Add(_cachedItems[identifier]);
            }

            return result;
        }

        public async Task<IEnumerable<Item>> GetBestStoriesOrderedByScore()
        {
            return (await GetBestStories()).OrderBy(x => x.Score).Take(20);
        }
    }
}