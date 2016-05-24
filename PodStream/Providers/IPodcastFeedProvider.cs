using PodStream.Models;

namespace PodStream.Providers
{
    public interface IPodcastFeedProvider
    {
        PodcastFeed Get(string feedUrl);
    }
}