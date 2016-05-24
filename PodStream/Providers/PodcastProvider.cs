using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PodStream.Providers.Models.PodcastApi;

namespace PodStream.Providers
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

        public Channel GetShows(string channel)
        {
            var jsonResponse = webClient.DownloadString(
                    $"http://www.dr.dk/AllePodcast/api/GetByFirst?letter=&channel={channel}&take=undefined");
            var parsedResponse = JsonConvert.DeserializeObject<Channel>(jsonResponse);
            return parsedResponse;
        }
    }
}
