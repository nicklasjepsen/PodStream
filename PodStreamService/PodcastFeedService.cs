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

        public IEnumerable<PodcastServiceFeedItem> GetFeedItems(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl))
                throw new ArgumentNullException(nameof(feedUrl));

            var feed = rssService.GetFeedItems(feedUrl);
            
            var channel = feed?.GetRssChannels()?.FirstOrDefault();
            if (channel == null)
                return new List<PodcastServiceFeedItem>();
            return (from rssItem in channel.GetRssItems()
                    select new PodcastServiceFeedItem
                    {
                        Title = rssItem.Title,
                        Url = rssItem.Link,
                        ExternalItemId = rssItem.GetGuid(),
                        PublishDate = rssItem.Date,
                        //FeedSource = source,
                        Summary = rssItem.Description,
                    }).ToList();

            //return new List<PodcastServiceFeedItem>
            //{
            //    new PodcastServiceFeedItem
            //    {
            //        PublishDate = DateTime.Now,
            //        Summary = "This is the feed item summary",
            //        Url = "http://www.dr.dk/mu/MediaRedirector/WithFileExtension/harddisken-2016-05-13.mp3?highestBitrate=True&amp;podcastDownload=True",
            //    }
            //};
        }
    }
}
