using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStream.Models
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
