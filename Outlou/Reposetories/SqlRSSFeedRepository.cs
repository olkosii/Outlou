using Microsoft.EntityFrameworkCore;
using Outlou.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml;

namespace Outlou.Reposetories
{
    public class SqlRSSFeedRepository : IRSSFeedRepository
    {
        private readonly ApplicationContext _context;
        public SqlRSSFeedRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Feed> AddRSSFeedAsync(Feed rssFeed)
        {
            var feed = await _context.Feeds.AddAsync(rssFeed);

            await _context.SaveChangesAsync();

            return feed.Entity;
        }

        public async Task<List<Feed>> GetRssFeedsAsync()
        {
            return await _context.Feeds.ToListAsync();
        }

        public async Task<SyndicationFeed> GetRssFeedAsync(int id)
        {
            var rssFeed = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == id);

            var feed = LoadFeed(rssFeed);

            return feed;
        }

        public async Task<IEnumerable<SyndicationItem>> GetUnreadNewsFromDateAsync(int feedId, DateTime fromDate, int userId)
        {
            var news = await GetNewsAsync(userId, feedId);

            var rssFeed = await GetRssFeedAsync(feedId);

            var unreadNewsFromDate = new List<SyndicationItem>();

            foreach (var item in rssFeed.Items)
            {
                if(item.PublishDate.UtcDateTime >= fromDate)
                {
                    if (news.Any(n => n.NewsId == item.Id && n.IsRead == true))
                        break;

                    unreadNewsFromDate.Add(item);
                }
            }

            return unreadNewsFromDate;
        }

        public async Task<ReadNews> SetNewsAsReadAsync(int feedId, string newsId, int userId)
        {
            var feed = await GetRssFeedAsync(feedId);

            var news = feed.Items.FirstOrDefault(n => n.Id == newsId);

            if(news != null)
            {
                if(ReadNewsExists(newsId))
                {
                    var existingNews = await _context.ReadNews.FirstOrDefaultAsync(n => n.NewsId == newsId);
                    existingNews.IsRead = true;
                    await _context.SaveChangesAsync();

                    return existingNews;
                }

                var readNews = new ReadNews()
                {
                    IsRead = true,
                    FeedId = feedId,
                    NewsId = newsId,
                    UserId = userId,
                    NewsDate = news.PublishDate.UtcDateTime
                };
                await _context.ReadNews.AddAsync(readNews);
                await _context.SaveChangesAsync();
                return readNews;
            }

            return null;
        }

        private bool ReadNewsExists(string newsId)
        {
            return _context.ReadNews.Any(n => n.NewsId == newsId) ? true : false;
        }
        private SyndicationFeed LoadFeed(Feed rssFeed)
        {
            XmlReader reader = XmlReader.Create(rssFeed.Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            return feed;
        }
        private async Task<List<ReadNews>> GetNewsAsync(int userId, int feedId)
        {
            return await _context.ReadNews
                .Where(urn => urn.UserId == userId &&
                              urn.FeedId == feedId).ToListAsync();
        }
    }
}
