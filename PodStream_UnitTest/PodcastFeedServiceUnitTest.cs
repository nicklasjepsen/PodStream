using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Moq;
using NUnit.Framework;
using PodStreamService;
using PodStreamService.Rss;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class PodcastFeedServiceUnitTest
    {
        [Test]
        public void TestGetFeedItems_ParamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new PodcastFeedService(new Mock<IRssService>().Object).GetFeedItems(null));
        }

        [Test]
        public void TestGetFeedItems()
        {
            var rssServiceMock = new Mock<IRssService>();
            rssServiceMock.Setup(rss => rss.GetFeedItems(TestConfig.ValidFeedUrl)).Returns(new BaseRssFeed<BaseRssChannel<BaseRssItem>>()
            {
                RssChannels = new List<BaseRssChannel<BaseRssItem>>()
                {
                    new BaseRssChannel<BaseRssItem>()
                    {
                        RssItems = new List<BaseRssItem>()
                        {
                            new BaseRssItem
                            {
                                Description = "Test rss item",
                                Guid = Guid.NewGuid().ToString(),
                                Link = "http://test.dk",
                                PublishedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                                Title = "Test title"
                            }
                        }
                    }
                }
            });
            
            var feedService = new PodcastFeedService(rssServiceMock.Object);
            var items = feedService.GetFeedItems(TestConfig.ValidFeedUrl);
            Assert.AreEqual(1, items.Count());
        }
    }
}
