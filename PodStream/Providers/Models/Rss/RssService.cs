using System;

namespace PodStream.Providers.Models.Rss
{
    public class RssService : IRssService
    {
        public BaseRssFeed<BaseRssChannel<BaseRssItem>> GetFeedItems(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException(nameof(url));

            return RssDeserializer.GetFeed(url);
        }
    }
}
