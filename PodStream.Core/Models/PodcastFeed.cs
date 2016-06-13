using System.Collections.Generic;

namespace PodStream.Core.Models
{
    public class PodcastFeed
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IEnumerable<PodcastFeedItem> FeedItems { get; set; }
    }
}
