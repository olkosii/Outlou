using Outlou.DataModels;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace Outlou.Reposetories
{
    public interface IRSSFeedRepository
    {
        Task<List<Feed>> GetRssFeedsAsync();
        Task<Feed> AddRSSFeedAsync(Feed rssFeed);
        Task<SyndicationFeed> GetRssFeedAsync(int id);
        Task<IEnumerable<SyndicationItem>> GetUnreadNewsFromDateAsync(int feedId, DateTime fromDate, int userId);
        Task<ReadNews> SetNewsAsReadAsync(int feedId, string newsId, int userId);
    }
}
