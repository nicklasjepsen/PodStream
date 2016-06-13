using System.Collections.Generic;
using PodStream.Core.Providers.Models.PodcastApi;

namespace PodStream.Core.Models
{
    public class Podcast
    {
        public string SelectedChannel { get; set; }
        public IEnumerable<PodcastFeed> AvailableChannels { get; set; }
        public Show SelectedShow { get; set; }
        public IEnumerable<PodcastFeed> AvailableShows { get; set; }

    }
}
