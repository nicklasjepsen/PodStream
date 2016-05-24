using System.Collections.Generic;
using PodStream.Providers.Models.PodcastApi;

namespace PodStream.Providers
{
    public interface IPodcastProvider
    {
        IEnumerable<string> GetChannels();
        Channel GetShows(string channel);
    }
}