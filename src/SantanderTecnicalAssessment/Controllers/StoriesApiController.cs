using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Santander
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/stories/")]
    public class StoriesApiController : Controller
    {
        private readonly IHackerNewsApi _api;

        public StoriesApiController(IHackerNewsApi api)
        {
            _api = api;
        }

        [HttpGet]
        [Route("best/")]
        public async Task<IActionResult> Best()
        {
            return Ok(await _api.GetBestStoriesOrderedByScore());
        }
    }
}