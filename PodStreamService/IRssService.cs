using System.Collections.Generic;
using PodStreamService.Rss;

namespace PodStreamService
{
    public interface IRssService
    {
        BaseRssFeed<BaseRssChannel<BaseRssItem>> GetFeedItems(string url);
    }
}