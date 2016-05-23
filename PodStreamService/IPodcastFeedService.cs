using System.Collections.Generic;

namespace PodStreamService
{
    public interface IPodcastFeedService
    {
        PodcastFeed GetFeed(string feedUrl);
    }
}