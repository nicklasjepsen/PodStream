using System.Collections.Generic;
using PodStream.Core.Providers.Models.PodcastApi;

namespace PodStream.Core.Providers
{
    public interface IPodcastProvider
    {
        IEnumerable<string> GetChannels();
        IEnumerable<Show> GetShows(string channel);
    }
}