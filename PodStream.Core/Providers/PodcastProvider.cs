using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PodStream.Core.Providers.Models.PodcastApi;

namespace PodStream.Core.Providers
{
    public class PodcastProvider : IPodcastProvider
    {
        private readonly IWebClient webClient;

        public PodcastProvider(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public IEnumerable<string> GetChannels()
        {
            var jsonResponse = webClient.DownloadString("http://www.dr.dk/AllePodcast/api/getchannels");
            jsonResponse = jsonResponse.Trim();
            return JsonConvert.DeserializeObject<string[]>(jsonResponse).Where(c => !string.IsNullOrEmpty(c));
        }

        public IEnumerable<Show> GetShows(string channel)
        {
            var allShows = new List<Show>();
            int totalCount;
            var curSkipCount = 0;
            do
            {
                var jsonResponse = webClient.DownloadString(
                    $"http://www.dr.dk/AllePodcast/api/GetByFirst?letter=&channel={channel}&skip={curSkipCount}");
                var parsedResponse = JsonConvert.DeserializeObject<Channel>(jsonResponse);
                allShows.AddRange(parsedResponse.Data);
                curSkipCount = allShows.Count;
                totalCount = parsedResponse.TotalCount;
            } while (allShows.Count < totalCount);
            
            return allShows;
        }
    }
}
