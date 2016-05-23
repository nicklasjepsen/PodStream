using System.Collections.Generic;

namespace PodStreamService
{
    public interface IPodcastFeedService
    {
        IEnumerable<PodcastServiceFeedItem> GetFeedItems(string feedUrl);
    }
}