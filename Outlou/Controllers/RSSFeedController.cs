using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Outlou.DataModels;
using Outlou.DomainModels;
using Outlou.Reposetories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Outlou.Controllers
{
    public class RSSFeedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRSSFeedRepository _repository;

        public RSSFeedController(IRSSFeedRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;  
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllFeedsAsync()
        {
            var feeds = await _repository.GetRssFeedsAsync();

            return Ok(_mapper.Map<List<Feed>>(feeds));
        }

        [HttpGet]
        [Route("[controller]/{feedId:int}")]
        public async Task<IActionResult> GetFeedAsync([FromRoute] int feedId)
        {
            var feed = await _repository.GetRssFeedAsync(feedId);

            return Ok(feed);
        }

        [HttpPost]
        [Route("[controller]/GetUnreadNewsFromDate")]
        public async Task<IActionResult> GetUnreadNewsAsync([FromBody] UnreadNewsFromDateRequest newsRequest)
        {
            var news = await _repository.GetUnreadNewsFromDateAsync(newsRequest.FeedId, newsRequest.FromDate, newsRequest.UserId);

            return Ok(news);
        }

        [HttpPost]
        [Route("[controller]/AddFeed")]
        public async Task<IActionResult> AddRssFeedAsync([FromBody] FeedDto feed)
        {
            var createdFeed = await _repository.AddRSSFeedAsync(_mapper.Map<Feed>(feed));

            return Ok(createdFeed);
        }

        [HttpPost]
        [Route("[controller]/SetNewsAsRead")]
        public async Task<IActionResult> SetNewsAsRead([FromBody] SetNewsAsReadRequest request)
        {
            var response = await _repository.SetNewsAsReadAsync(request.FeedId, request.NewsId, request.UserId);

            if(response != null)
                return Ok(response);

            return NotFound();
        }
    }
}
