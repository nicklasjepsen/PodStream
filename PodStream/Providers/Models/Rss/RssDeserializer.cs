using System;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace PodStream.Providers.Models.Rss
{
    /// <summary>
    /// Deserialize an RssFeed
    /// </summary>
    public static class RssDeserializer
    {
        public static BaseRssFeed<BaseRssChannel<BaseRssItem>> GetFeed(string feedUrl)
        {
            return GetFeed<BaseRssFeed<BaseRssChannel<BaseRssItem>>>(feedUrl);
        }

        /// <summary>
        /// Deserialize an RSS from an URL
        /// </summary>
        /// <typeparam name="T">The type of feed to deserialize into</typeparam>
        /// <param name="feedUrl">The location of the feed</param>
        /// <returns>The deserialized feed</returns>
        public static T GetFeed<T>(string feedUrl)
        {
            if (string.IsNullOrEmpty(feedUrl)) return default(T);

            var xs = new XmlSerializer(typeof(T));
            try
            {
                var xmlReaderSettings = new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                };
                T rss;
                using (var reader = XmlReader.Create(feedUrl, xmlReaderSettings))
                {
                    rss = (T)xs.Deserialize(reader);
                }
                return rss;
            }
            catch (WebException)
            {
                return default(T);
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
        }
    }
}