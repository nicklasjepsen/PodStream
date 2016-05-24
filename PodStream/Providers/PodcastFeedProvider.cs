using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodStream.Models;
using PodStream.Providers.Models.Rss;

namespace PodStream.Providers
{
    public class PodcastFeedProvider : IPodcastFeedProvider
    {
        private readonly IRssService rssService;

        public PodcastFeedProvider(IRssService rssService)
        {
            this.rssService = rssService;
        }

        public PodcastFeed Get(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl))
                throw new ArgumentNullException(nameof(feedUrl));

            var feed = rssService.GetFeedItems(feedUrl);

            // ATM we are only supporting single channel RSS
            var channel = feed?.GetRssChannels()?.FirstOrDefault();
            var rssItems = channel?.GetRssItems();
            if (rssItems == null)
                return null;

            var feedResult = new PodcastFeed
            {
                FeedItems = (from rssItem in channel.GetRssItems()
                             select new PodcastFeedItem
                             {
                                 Title = rssItem.Title,
                                 Url = rssItem.Enclosure?.Url,
                                 SizeInBytes = rssItem.Enclosure?.Lenght,
                                 ExternalItemId = rssItem.GetGuid(),
                                 PublishDate = rssItem.Date,
                                 Summary = rssItem.Description,
                                 Duration = rssItem.Duration,
                             }).ToList(),
                Title = channel.Title,
                Category = channel.Category,
                Description = channel.Description,
                Image = channel.Image?.Url,
                Url = channel.Link
            };

            return feedResult;
        }
    }
}
