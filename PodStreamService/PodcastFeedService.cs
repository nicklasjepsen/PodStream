using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStreamService
{
    public class PodcastFeedService : IPodcastFeedService
    {
        private readonly IRssService rssService;

        public PodcastFeedService(IRssService rssService)
        {
            this.rssService = rssService;
        }

        public PodcastFeed GetFeed(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl))
                throw new ArgumentNullException(nameof(feedUrl));

            var feed = rssService.GetFeedItems(feedUrl);

            // ATM we are only supporting single channels RSS
            var channel = feed?.GetRssChannels()?.FirstOrDefault();
            if (channel == null)
                return null;

            var feedResult = new PodcastFeed
            {
                FeedItems = (from rssItem in channel.GetRssItems()
                             select new PodcastServiceFeedItem
                             {
                                 Title = rssItem.Title,
                                 Url = rssItem.Link,
                                 ExternalItemId = rssItem.GetGuid(),
                                 PublishDate = rssItem.Date,
                                 Summary = rssItem.Description,
                             }).ToList(),
                Title = channel.Title,
                Category = channel.Category,
                Description = channel.Description,
                Image = channel.Image.Url,
                Url = channel.Link
            };

            return feedResult;
        }
    }
}
