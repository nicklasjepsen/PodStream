using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStreamService
{
    public class PodcastFeedService : IPodcastFeedService
    {
        public IEnumerable<PodcastServiceFeedItem> GetFeedItems(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl))
                throw new ArgumentNullException(nameof(feedUrl));
            return new List<PodcastServiceFeedItem>
            {
                new PodcastServiceFeedItem
                {
                    PublishDate = DateTime.Now,
                    Summary = "This is the feed item summary",
                    Url = "http://www.dr.dk/mu/MediaRedirector/WithFileExtension/harddisken-2016-05-13.mp3?highestBitrate=True&amp;podcastDownload=True",
                }
            };
        }
    }
}
