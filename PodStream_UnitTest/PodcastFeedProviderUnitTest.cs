using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Moq;
using NUnit.Framework;
using PodStream.Core.Providers;
using PodStream.Core.Providers.Models.Rss;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class PodcastFeedProviderUnitTest
    {
        // TODO: Add tests... 

        // So far this unit test only proves that we are able to test the PodcastFeedProvider because 
        // it is injected and separated from the rest of the Controller logic.

        [Test]
        public void TestGetFeedItems_ParamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PodcastFeedProvider(new Mock<IRssService>().Object).Get(null));
        }

        [Test]
        public void TestGetFeedItems()
        {
            var rssServiceMock = new Mock<IRssService>();
            rssServiceMock.Setup(rss => rss.GetFeedItems(TestConfig.ValidFeedUrl)).Returns(new BaseRssFeed<BaseRssChannel<BaseRssItem>>()
            {
                RssChannels = new List<BaseRssChannel<BaseRssItem>>
                {
                    new BaseRssChannel<BaseRssItem>
                    {
                        RssItems = new List<BaseRssItem>
                        {
                            new BaseRssItem
                            {
                                Description = "Test rss item",
                                Guid = Guid.NewGuid().ToString(),
                                Enclosure = new RssEnclosure() {Url = "http://test.dk"},
                                PublishedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                                Title = "Test title"
                            }
                        }
                    }
                }
            });

            var feedService = new PodcastFeedProvider(rssServiceMock.Object);
            var feed = feedService.Get(TestConfig.ValidFeedUrl);
            Assert.AreEqual(1, feed.FeedItems.Count());
        }
    }
}
