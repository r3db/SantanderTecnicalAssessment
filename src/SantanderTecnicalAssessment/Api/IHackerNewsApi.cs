using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Santander
{
    public interface IHackerNewsApi
    {
        Task<IEnumerable<Item>> GetBestStories();
        Task<IEnumerable<Story>> GetBestStoriesOrderedByScore();
    }
}