using PodStream.Core.Models;

namespace PodStream.Core.Providers
{
    public interface IPodcastFeedProvider
    {
        PodcastFeed Get(string feedUrl);
    }
}