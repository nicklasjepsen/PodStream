using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodStreamService;

namespace PodStream.Models
{
    public class Feed
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public IEnumerable<PodcastServiceFeedItem> FeedItems { get; set; }
    }
}
