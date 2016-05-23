using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PodStreamService.Rss;

namespace PodStreamService
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
