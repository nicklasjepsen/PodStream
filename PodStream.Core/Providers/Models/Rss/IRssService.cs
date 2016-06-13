namespace PodStream.Core.Providers.Models.Rss
{
    public interface IRssService
    {
        BaseRssFeed<BaseRssChannel<BaseRssItem>> GetFeedItems(string url);
    }
}