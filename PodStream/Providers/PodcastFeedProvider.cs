using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodStream.Models;
using PodStream.Providers.Models.Rss;

namespace PodStream.Providers
{
    public class PodcastFeedProvider : IPodcastFeedProvider
    {
        private readonly IRssService rssService;

        public PodcastFeedProvider(IRssService rssService)
        {
            this.rssService = rssService;
        }

        public PodcastFeed Get(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl))
                throw new ArgumentNullException(nameof(feedUrl));

            var feed = rssService.GetFeedItems(feedUrl);

            // ATM we are only supporting single channel RSS
            var channel = feed?.GetRssChannels()?.FirstOrDefault();
            var rssItems = channel?.GetRssItems();
            if (rssItems == null)
                return null;

            var feedResult = new PodcastFeed
            {
                FeedItems = (from rssItem in channel.GetRssItems()
                             select new PodcastFeedItem
                             {
                                 Title = rssItem.Title,
                                 Url = rssItem.Enclosure?.Url,
                                 SizeInBytes = rssItem.Enclosure?.Lenght,
                                 ExternalItemId = rssItem.GetGuid(),
                                 PublishDate = GetDisplayDate(rssItem.Date),
                                 Summary = rssItem.Description,
                                 Duration = GetDisplayDuration(rssItem.Duration),
                             }).ToList(),
                Title = channel.Title,
                Category = channel.Category,
                Description = channel.Description,
                Url = channel.Link
            };

            return feedResult;
        }

        private static string GetDisplayDuration(string duration)
        {
            if (string.IsNullOrEmpty(duration))
                return "?";

            if (!duration.Contains(':'))
                return "?";

            var splitted = duration.Split(':');
            if (splitted.Length < 3)
                return "?";

            var result = string.Empty;
            var hours = splitted[0].Replace("0", "");
            var mins = splitted[1].Replace("0", "");
            var secs = splitted[2].Replace("0", "");
            if (!string.IsNullOrEmpty(hours))
                result = hours + "t";
            if (!string.IsNullOrEmpty(mins))
                result += " " + mins + "m";
            if (!string.IsNullOrEmpty(secs))
                result += " " + secs + "s";

            return result;
        }

        private string GetDisplayDate(DateTime date)
        {
           
            if (date > DateTime.Now.AddDays(-1))
            {
                return "i dag";
            }
            if (date > DateTime.Now.AddDays(-30))
            {
                return (int)(DateTime.Now - date).TotalDays + " dag(e) siden";
            }
            else
            {
                return date.ToString("dd-MM-yyyy");
            }
        }
    }
}
